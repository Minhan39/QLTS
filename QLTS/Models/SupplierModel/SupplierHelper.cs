using DevExpress.Web.Mvc;
using QLTS.Models.AssetModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.SupplierModel
{
    public class SupplierHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<Supplier> GetSuppliers()
        {
            return db.Suppliers.OrderBy(i => i.Name).ToList();
        }
        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        //Kiểm tra tồn tại các tài sản thuộc nhà cung cấp
        public static bool Validation(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<Asset> assets = AssetHelper.GetAssetsNotJoin().Where(i => selectedIds.Contains((int)i.SupplierId));
            if (assets.Count() > 0)
            {
                return false;
            }
            return true;
        }
        public static void AddNewRecord(Supplier supplier)
        {
            supplier.AtCreate = DateTime.Now;
            db.Suppliers.Add(supplier);
            db.SaveChanges();
        }

        public static void UpdateRecord(Supplier supplier)
        {
            Supplier item = db.Suppliers.Find(supplier.Id);
            item.Name = supplier.Name;
            item.Address = supplier.Address;
            item.BusinessRegistrationCode = supplier.BusinessRegistrationCode;
            item.City = supplier.City;
            item.Country = supplier.Country;
            item.District = supplier.District;
            item.Email = supplier.Email;
            item.Fax = supplier.Fax;
            item.GroupI = supplier.GroupI;
            item.LinkWebsite = supplier.LinkWebsite;
            item.Phone = supplier.Phone;
            item.Subject = supplier.Subject;
            item.SupplierId = supplier.SupplierId;
            item.TaxCode = supplier.TaxCode;
            item.Ward = supplier.Ward;
            item.AtUpdate = DateTime.Now;
            db.SaveChanges();
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<Supplier> suppliers = GetSuppliers().Where(i => selectedIds.Contains(i.Id));
            db.Suppliers.RemoveRange(suppliers);
            db.SaveChanges();
        }
    }
}