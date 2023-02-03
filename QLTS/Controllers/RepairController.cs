using QLTS.Models;
using QLTS.Models.RepairModel;
using System;
using System.Web.Mvc;

namespace QLTS.Controllers
{
    public class RepairController : BaseController
    {
        public ActionResult Index()
        {
            return View(RepairHelper.GetRepairs());
        }
        public ActionResult GridViewDetailsPage(long id)
        {
            ViewBag.ShowBackButton = true;
            return View(RepairHelper.GetRepairs().Find(i => i.Id == id));
        }
        public ActionResult GridViewPartial()
        {
            return PartialView("GridViewPartial", RepairHelper.GetRepairs());
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return GridViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewAddNewPartial(Repair repair)
        {
            return UpdateModelWithDataValidation(repair, RepairHelper.AddNewRecord);
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(Repair repair)
        {
            return UpdateModelWithDataValidation(repair, RepairHelper.UpdateRecord);
        }

        private ActionResult UpdateModelWithDataValidation(Repair repair, Action<Repair> updateMethod)
        {
            if (ModelState.IsValid)
                SafeExecute(() => updateMethod(repair));
            else
                ViewBag.GeneralError = "Ôi không, đã có lỗi xảy ra!";
            return GridViewPartial();
        }
        private void PerformDelete()
        {
            if (!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
                RepairHelper.DeleteRecords(Request.Params["SelectedRows"]);
        }
    }
}