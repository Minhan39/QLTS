using QLTS.Models;
using QLTS.Models.AssetAllocationModel;
using System;
using System.Web.Mvc;

namespace QLTS.Controllers
{
    public class AssetAllocationController : BaseController
    {
        public ActionResult Index()
        {
            return View(AssetAllocationHelper.GetAssetAllocations());
        }
        public ActionResult GridViewDetailsPage(long id)
        {
            ViewBag.ShowBackButton = true;
            return View(AssetAllocationHelper.GetAssetAllocations().Find(i => i.Id == id));
        }
        public ActionResult GridViewPartial()
        {
            return PartialView("GridViewPartial", AssetAllocationHelper.GetAssetAllocations());
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return GridViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewAddNewPartial(AssetAllocation assetAllocation)
        {
            if (!AssetAllocationHelper.Validation(assetAllocation.AssetId, (long)assetAllocation.Quantity))
            {
                string s = "Tài sản đang không đủ số lượng theo yêu cầu";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            return UpdateModelWithDataValidation(assetAllocation, AssetAllocationHelper.AddNewRecord);
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(AssetAllocation assetAllocation)
        {
            if (!AssetAllocationHelper.Validation(assetAllocation.AssetId, (long)assetAllocation.Quantity, assetAllocation.RoomId))
            {
                string s = "Tài sản đang không đủ số lượng theo yêu cầu";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            return UpdateModelWithDataValidation(assetAllocation, AssetAllocationHelper.UpdateRecord);
        }

        private ActionResult UpdateModelWithDataValidation(AssetAllocation assetAllocation, Action<AssetAllocation> updateMethod)
        {
            if (ModelState.IsValid)
                SafeExecute(() => updateMethod(assetAllocation));
            else
                ViewBag.GeneralError = "Ôi không, đã có lỗi xảy ra!";
            return GridViewPartial();
        }
        private void PerformDelete()
        {
            if (!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
                AssetAllocationHelper.DeleteRecords(Request.Params["SelectedRows"]);
        }
    }
}