using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.RepairModel
{
    public class RepairHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<RepairModel> GetRepairs()
        {
            return db.Repairs.Select(n => new RepairModel
            {
                Id = n.Id,
                InvoiceCode = n.InvoiceCode,
                AssetId = n.AssetId,
                Type = n.Type,
                Traders = n.Traders,
                SupplierAddress = n.SupplierAddress,
                SupplierFax = n.SupplierFax,
                SupplierMail = n.SupplierMail,
                SupplierName = n.SupplierName,
                SupplierPhone = n.SupplierPhone,
                AtRepair = n.AtRepair,
                RepairTime = n.RepairTime,
                Note = n.Note,
                AtCreate = n.AtCreate,
                AtUpdate = n.AtUpdate
            }).OrderBy(i => i.AtCreate).ToList();
        }
        public static List<Repair> GetRepairsNotJoin()
        {
            return db.Repairs.OrderBy(i => i.AtCreate).ToList();
        }
        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        public static void AddNewRecord(Repair repair)
        {
            repair.AtCreate = DateTime.Now;
            db.Repairs.Add(repair);
            db.SaveChanges();
        }

        public static void UpdateRecord(Repair repair)
        {
            Repair item = db.Repairs.Find(repair.Id);
            item.InvoiceCode = repair.InvoiceCode;
            item.AssetId = repair.AssetId;
            item.Type = repair.Type;
            item.Traders = repair.Traders;
            item.SupplierAddress = repair.SupplierAddress;
            item.SupplierFax = repair.SupplierFax;
            item.SupplierMail = repair.SupplierMail;
            item.SupplierName = repair.SupplierName;
            item.SupplierPhone = repair.SupplierPhone;
            item.AtRepair = repair.AtRepair;
            item.RepairTime = repair.RepairTime;
            item.Note = repair.Note;
            item.AtUpdate = DateTime.Now;
            db.SaveChanges();
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<Repair> repairs = GetRepairsNotJoin().Where(i => selectedIds.Contains(i.Id));
            db.Repairs.RemoveRange(repairs);
            db.SaveChanges();
        }
    }
}