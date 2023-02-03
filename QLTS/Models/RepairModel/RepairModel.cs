using QLTS.Models.AssetModel;
using System;

namespace QLTS.Models.RepairModel
{
    public class RepairModel
    {
        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public string Type { get; set; }
        public string Traders { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierFax { get; set; }
        public string SupplierMail { get; set; }
        public Nullable<System.DateTime> AtRepair { get; set; }
        public Nullable<int> RepairTime { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> AtCreate { get; set; }
        public Nullable<System.DateTime> AtUpdate { get; set; }
        public int AssetId
        {
            get
            {
                return (Asset != null) ? Asset.Id : -1;
            }
            set
            {
                Asset = AssetHelper.GetAssetsNotJoin().Find(n => n.Id == value);
            }
        }
        public Asset Asset { get; private set; }
    }
}