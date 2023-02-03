using DevExpress.Web.Mvc;
using QLTS.Models;
using QLTS.Models.AssetModel;
using System;
using System.Web.Mvc;

namespace QLTS.Controllers
{
    public class AssetController : BaseController
    {
        public ActionResult Index()
        {
            return View(AssetHelper.GetAssets());
        }
        public ActionResult GridViewDetailsPage(long id)
        {
            ViewBag.ShowBackButton = true;
            return View(AssetHelper.GetAssets().Find(i => i.Id == id));
        }
        public ActionResult GridViewPartial()
        {
            return PartialView("GridViewPartial", AssetHelper.GetAssets());
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return GridViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewAddNewPartial(Asset asset)
        {
            return UpdateModelWithDataValidation(asset, AssetHelper.AddNewRecord);
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(Asset asset)
        {
            return UpdateModelWithDataValidation(asset, AssetHelper.UpdateRecord);
        }

        private ActionResult UpdateModelWithDataValidation(Asset asset, Action<Asset> updateMethod)
        {
            if (ModelState.IsValid)
                SafeExecute(() => updateMethod(asset));
            else
                ViewBag.GeneralError = "Ôi không, đã có lỗi xảy ra!";
            return GridViewPartial();
        }
        private void PerformDelete()
        {
            if (!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
                AssetHelper.DeleteRecords(Request.Params["SelectedRows"]);
        }
        public ActionResult BinaryImageColumnPhotoUpdate()
        {
            return BinaryImageEditExtension.GetCallbackResult();
        }
    }
}