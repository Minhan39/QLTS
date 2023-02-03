using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.AreaModel
{
    public class AreaHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<Area> GetAreas()
        {
            return db.Areas.OrderBy(i => i.Name).ToList();
        }
        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        public static void AddNewRecord(Area area)
        {
            area.AtCreate = DateTime.Now;
            db.Areas.Add(area);
            db.SaveChanges();
        }

        public static void UpdateRecord(Area area)
        {
            Area item = db.Areas.Find(area.Id);
            item.Name = area.Name;
            item.AtUpdate = DateTime.Now;
            db.SaveChanges();
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<Area> areas = GetAreas().Where(i => selectedIds.Contains(i.Id));
            db.Areas.RemoveRange(areas);
            db.SaveChanges();
        }
    }
}