using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.RoomModel
{
    public class RoomHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<RoomModel> GetRooms()
        {
            List<RoomModel> list = db.Rooms.Join(db.Areas, r => r.AreaId, a => a.Id, (r, a) => new RoomModel
            {
                Id = r.Id,
                Name = r.Name,
                Floor = r.Floor,
                AreaId = r.AreaId,
                Area = a,
                AtCreate = r.AtCreate,
                AtUpdate = r.AtUpdate
            }).ToList();
            return list;
        }
        public static List<Room> GetRoomsNotJoin()
        {
            return db.Rooms.OrderBy(i => i.Name).ToList();
        }
        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        public static void AddNewRecord(Room room)
        {
            room.AtCreate = DateTime.Now;
            db.Rooms.Add(room);
            db.SaveChanges();
        }

        public static void UpdateRecord(Room room)
        {
            Room item = db.Rooms.Find(room.Id);
            item.Name = room.Name;
            item.Floor = room.Floor;
            item.AreaId = room.AreaId;
            item.AtUpdate = DateTime.Now;
            db.SaveChanges();
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<Room> rooms = GetRoomsNotJoin().Where(i => selectedIds.Contains(i.Id));
            db.Rooms.RemoveRange(rooms);
            db.SaveChanges();
        }
    }
}