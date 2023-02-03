using QLTS.Models;
using QLTS.Models.RoomModel;
using System;
using System.Web.Mvc;

namespace QLTS.Controllers
{
    public class RoomController : BaseController
    {
        public ActionResult Index()
        {
            return View(RoomHelper.GetRooms());
        }
        public ActionResult GridViewDetailsPage(long id)
        {
            ViewBag.ShowBackButton = true;
            return View(RoomHelper.GetRooms().Find(i => i.Id == id));
        }
        public ActionResult GridViewPartial()
        {
            return PartialView("GridViewPartial", RoomHelper.GetRooms());
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return GridViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewAddNewPartial(Room room)
        {
            return UpdateModelWithDataValidation(room, RoomHelper.AddNewRecord);
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(Room room)
        {
            return UpdateModelWithDataValidation(room, RoomHelper.UpdateRecord);
        }

        private ActionResult UpdateModelWithDataValidation(Room room, Action<Room> updateMethod)
        {
            if (ModelState.IsValid)
                SafeExecute(() => updateMethod(room));
            else
                ViewBag.GeneralError = "Ôi không, đã có lỗi xảy ra!";
            return GridViewPartial();
        }
        private void PerformDelete()
        {
            if (!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
                RoomHelper.DeleteRecords(Request.Params["SelectedRows"]);
        }
    }
}