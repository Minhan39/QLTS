using QLTS.Models;
using QLTS.Models.ManagementAssignmentModel;
using System;
using System.Web.Mvc;

namespace QLTS.Controllers
{
    public class ManagementAssignmentController : BaseController
    {
        public ActionResult Index()
        {
            return View(ManagementAssignmentHelper.GetManagementAssignments());
        }
        public ActionResult GridViewDetailsPage(long id)
        {
            ViewBag.ShowBackButton = true;
            return View(ManagementAssignmentHelper.GetManagementAssignments().Find(i => i.Id == id));
        }
        public ActionResult GridViewPartial()
        {
            return PartialView("GridViewPartial", ManagementAssignmentHelper.GetManagementAssignments());
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return GridViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewAddNewPartial(ManagementAssignment managementAssignment)
        {
            if (!ManagementAssignmentHelper.Validation(managementAssignment.RoomId))
            {
                string s = "Phòng/Sân đã được phân công quản lý";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            return UpdateModelWithDataValidation(managementAssignment, ManagementAssignmentHelper.AddNewRecord);
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(ManagementAssignment managementAssignment)
        {
            if (!ManagementAssignmentHelper.Validation(managementAssignment.RoomId, managementAssignment.Id))
            {
                string s = "Phòng/Sân đã được phân công quản lý";
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            return UpdateModelWithDataValidation(managementAssignment, ManagementAssignmentHelper.UpdateRecord);
        }

        private ActionResult UpdateModelWithDataValidation(ManagementAssignment managementAssignment, Action<ManagementAssignment> updateMethod)
        {
            if (ModelState.IsValid)
                SafeExecute(() => updateMethod(managementAssignment));
            else
                ViewBag.GeneralError = "Ôi không, đã có lỗi xảy ra!";
            return GridViewPartial();
        }
        private void PerformDelete()
        {
            if (!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
                ManagementAssignmentHelper.DeleteRecords(Request.Params["SelectedRows"]);
        }
    }
}