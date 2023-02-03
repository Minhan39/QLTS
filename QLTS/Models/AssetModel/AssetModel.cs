using QLTS.Models.CategoryModel;
using QLTS.Models.SupplierModel;
using QLTS.Models.UnitModel;
using System;

namespace QLTS.Models.AssetModel
{
    public class AssetModel
    {
        public int Id { get; set; }
        public string AssetId { get; set; }
        public string BarCode { get; set; }
        public Nullable<System.DateTime> AtImport { get; set; }
        public string Name { get; set; }
        public Nullable<int> CategoryId
        {
            get
            {
                return (Category != null) ? Category.Id : -1;
            }
            set
            {
                Category = CategoryHelper.GetCategoriesNotJoin().Find(n => n.Id == value);
            }
        }
        public Category Category { get; private set; }
        public string Status { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> UnitId
        {
            get
            {
                return (Unit != null) ? Unit.Id : -1;
            }
            set
            {
                Unit = UnitHelper.GetUnits().Find(n => n.Id == value);
            }
        }
        public Unit Unit { get; private set; }
        public string Country { get; set; }
        public Nullable<int> SupplierId
        {
            get
            {
                return (Supplier != null) ? Supplier.Id : -1;
            }
            set
            {
                Supplier = SupplierHelper.GetSuppliers().Find(n => n.Id == value);

            }
        }
        public Supplier Supplier { get; private set; }
        public string Uses { get; set; }
        public Nullable<System.DateTime> AtBuy { get; set; }
        public Nullable<System.DateTime> AtUsing { get; set; }
        public Nullable<System.DateTime> AtStopUsing { get; set; }
        public Nullable<System.DateTime> AtLiquidation { get; set; }
        public string Number { get; set; }
        public string Serial { get; set; }
        public string Part { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public Nullable<decimal> Wattage { get; set; }
        public Nullable<decimal> WMax { get; set; }
        public Nullable<decimal> WMin { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> SpecificGravity { get; set; }
        public Nullable<decimal> Length { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<decimal> Radius { get; set; }
        public Nullable<decimal> Perimeter { get; set; }
        public Nullable<decimal> Area { get; set; }
        public string NoteSpecification { get; set; }
        public Nullable<int> Maintenance { get; set; }
        public Nullable<int> Accreditation { get; set; }
        public Nullable<int> Inventory { get; set; }
        public Nullable<int> Insurance { get; set; }
        public Nullable<decimal> Fuel { get; set; }
        public Nullable<decimal> Diesel { get; set; }
        public Nullable<int> Tire { get; set; }
        public Nullable<int> Battery { get; set; }
        public Nullable<System.DateTime> AtCreate { get; set; }
        public Nullable<System.DateTime> AtUpdate { get; set; }
        public byte[] Image { get; set; }
    }
}