using QLTS.Models;
using QLTS.Models.DeviceErrorReportModel;
using System;
using System.Web.Mvc;

namespace QLTS.Controllers
{
    public class DeviceErrorReportController : BaseController
    {
        // GET: DeviceErrorReport
        public ActionResult Index()
        {
            return View(DeviceErrorReportHelper.GetDeviceErrorReports());
        }
        public ActionResult Report()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report(DeviceErrorReport deviceErrorReport)
        {
            if (ModelState.IsValid)
                SafeExecute(() => DeviceErrorReportHelper.AddNewRecord(deviceErrorReport));
            else
                ViewBag.GeneralError = "Ôi không, đã có lỗi xảy ra!";
            return View();
        }
        public ActionResult GridViewDetailsPage(long id)
        {
            ViewBag.ShowBackButton = true;
            return View(DeviceErrorReportHelper.GetDeviceErrorReports().Find(i => i.Id == id));
        }
        public ActionResult GridViewPartial()
        {
            return PartialView("GridViewPartial", DeviceErrorReportHelper.GetDeviceErrorReports());
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return GridViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(DeviceErrorReport deviceErrorReport)
        {
            return UpdateModelWithDataValidation(deviceErrorReport, DeviceErrorReportHelper.UpdateRecord);
        }

        private ActionResult UpdateModelWithDataValidation(DeviceErrorReport deviceErrorReport, Action<DeviceErrorReport> updateMethod)
        {
            if (ModelState.IsValid)
                SafeExecute(() => updateMethod(deviceErrorReport));
            else
                ViewBag.GeneralError = "Ôi không, đã có lỗi xảy ra!";
            return GridViewPartial();
        }
        private void PerformDelete()
        {
            if (!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
                DeviceErrorReportHelper.DeleteRecords(Request.Params["SelectedRows"]);
        }
    }
}