﻿using QLTS.Models;
using QLTS.Models.CategoryModel;
using System;
using System.Web.Mvc;

namespace QLTS.Controllers
{
    public class CategoryController : BaseController
    {
        public ActionResult Index()
        {
            return View(CategoryHelper.GetCategories());
        }
        public ActionResult GridViewDetailsPage(long id)
        {
            ViewBag.ShowBackButton = true;
            return View(CategoryHelper.GetCategories().Find(i => i.Id == id));
        }
        public ActionResult GridViewPartial()
        {
            return PartialView("GridViewPartial", CategoryHelper.GetCategories());
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
            {
                if (!CategoryHelper.Validation(Request.Params["SelectedRows"]))
                {
                    return Json("Xoá thất bại, vui lòng xoá hết quan hệ với các phân loại con và các tài sản liên quan", JsonRequestBehavior.AllowGet);
                }
                SafeExecute(() => PerformDelete());
            }
            return GridViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewAddNewPartial(Category category)
        {
            return UpdateModelWithDataValidation(category, CategoryHelper.AddNewRecord);
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(Category category)
        {
            return UpdateModelWithDataValidation(category, CategoryHelper.UpdateRecord);
        }

        private ActionResult UpdateModelWithDataValidation(Category category, Action<Category> updateMethod)
        {
            if (ModelState.IsValid)
                SafeExecute(() => updateMethod(category));
            else
                ViewBag.GeneralError = "Ôi không, đã có lỗi xảy ra!";
            return GridViewPartial();
        }
        private void PerformDelete()
        {
            if (!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
            {
                CategoryHelper.DeleteRecords(Request.Params["SelectedRows"]);
            }
                
        }
    }
}