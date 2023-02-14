using DevExpress.Web.Mvc;
using QLTS.Models.ReportModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.AssetModel
{
    public class AssetHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<AssetModel> GetAssets()
        {
            List<AssetModel> list = db.Assets.Select(n => new AssetModel
            {
                Id = n.Id,
                Name = n.Name,
                AssetId = n.AssetId,
                BarCode = n.BarCode,
                AtImport = n.AtImport,
                CategoryId = n.CategoryId,
                Status = n.Status,
                Quantity = n.Quantity,
                Amount = n.Amount,
                UnitId = n.UnitId,
                Country = n.Country,
                SupplierId = n.SupplierId,
                Uses = n.Uses,
                AtBuy = n.AtBuy,
                AtUsing = n.AtUsing,
                AtStopUsing = n.AtStopUsing,
                AtLiquidation = n.AtLiquidation,
                Number = n.Number,
                Serial = n.Serial,
                Part = n.Part,
                Model = n.Model,
                LicensePlate = n.LicensePlate,
                Image = n.Image,
                Wattage = n.Wattage,
                WMax = n.WMax,
                WMin = n.WMin,
                SpecificGravity = n.SpecificGravity,
                Length = n.Length,
                Weight = n.Weight,
                Height = n.Height,
                Radius = n.Radius,
                Perimeter = n.Perimeter,
                Area = n.Area,
                NoteSpecification = n.NoteSpecification,
                Maintenance = n.Maintenance,
                Accreditation = n.Accreditation,
                Inventory = n.Inventory,
                Insurance = n.Insurance,
                Fuel = n.Fuel,
                Diesel = n.Diesel,
                Tire = n.Tire,
                Battery = n.Battery,
                AtCreate = n.AtCreate,
                AtUpdate = n.AtUpdate
            }).ToList();
            return list;
        }
        public static List<Asset> GetAssetsNotJoin()
        {
            return db.Assets.OrderBy(i => i.Name).ToList();
        }
        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        public static void AddNewRecord(Asset asset)
        {
            asset.AtCreate = DateTime.Now;
            db.Assets.Add(asset);
            db.SaveChanges();

            decimal total = (decimal)((asset.Amount == null || asset.Quantity == null) ? 0 : asset.Amount * asset.Quantity);
            int numbers = (int)((asset.Quantity == null) ? 0 : asset.Quantity);
            DataReportHelper.UpdateReport(total, numbers);
            DataReportHelper.UpdateReportCategory(total, numbers, asset.CategoryId);
        }

        public static void UpdateRecord(Asset asset)
        {
            Asset item = db.Assets.Find(asset.Id);
            decimal newTotal = (decimal)((asset.Amount == null || asset.Quantity == null) ? 0 : asset.Amount * asset.Quantity);
            decimal oldTotal = (decimal)((item.Amount == null || item.Quantity == null) ? 0 : item.Amount * item.Quantity);
            int newNumbers = (int)((asset.Quantity == null) ? 0 : asset.Quantity);
            int oldNumbers = (int)((item.Quantity == null) ? 0 : item.Quantity);
            int? oldCategoryId = item.CategoryId;
            item.Name = asset.Name;
            item.AssetId = asset.AssetId;
            item.BarCode = asset.BarCode;
            item.AtImport = asset.AtImport;
            item.CategoryId = asset.CategoryId;
            item.Status = asset.Status;
            item.Quantity = asset.Quantity;
            item.Amount = asset.Amount;
            item.UnitId = asset.UnitId;
            item.Country = asset.Country;
            item.SupplierId = asset.SupplierId;
            item.Uses = asset.Uses;
            item.AtBuy = asset.AtBuy;
            item.AtUsing = asset.AtUsing;
            item.AtStopUsing = asset.AtStopUsing;
            item.AtLiquidation = asset.AtLiquidation;
            item.Number = asset.Number;
            item.Serial = asset.Serial;
            item.Part = asset.Part;
            item.Model = asset.Model;
            item.LicensePlate = asset.LicensePlate;
            item.Image = asset.Image;
            item.Wattage = asset.Wattage;
            item.WMax = asset.WMax;
            item.WMin = asset.WMin;
            item.SpecificGravity = asset.SpecificGravity;
            item.Length = asset.Length;
            item.Weight = asset.Weight;
            item.Height = asset.Height;
            item.Radius = asset.Radius;
            item.Perimeter = asset.Perimeter;
            item.Area = asset.Area;
            item.NoteSpecification = asset.NoteSpecification;
            item.Maintenance = asset.Maintenance;
            item.Accreditation = asset.Accreditation;
            item.Inventory = asset.Inventory;
            item.Insurance = asset.Insurance;
            item.Fuel = asset.Fuel;
            item.Diesel = asset.Diesel;
            item.Tire = asset.Tire;
            item.Battery = asset.Battery;
            item.AtUpdate = DateTime.Now;
            db.SaveChanges();

            DataReportHelper.UpdateReport(newTotal - oldTotal, newNumbers - oldNumbers);
            if (oldCategoryId == item.CategoryId)
                DataReportHelper.UpdateReportCategory(-1 * newTotal, -1 * newNumbers, item.CategoryId);
            else
                DataReportHelper.UpdateReportCategory(-1 * oldTotal, newTotal, -1 * oldNumbers, newNumbers, oldCategoryId, item.CategoryId);
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<Asset> assets = GetAssetsNotJoin().Where(i => selectedIds.Contains(i.Id));

            decimal total = 0;
            int numbers = 0;
            foreach(Asset item in assets)
            {
                decimal addTotal = (decimal)((item.Amount == null || item.Quantity == null) ? 0 : item.Amount * item.Quantity);
                total += addTotal;
                int addNumbers = (int)((item.Quantity == null) ? 0 : item.Quantity);
                numbers += addNumbers;
                DataReportHelper.UpdateReportCategory(-1 * addTotal, -1 * addNumbers, item.CategoryId);
            }

            db.Assets.RemoveRange(assets);
            db.SaveChanges();

            DataReportHelper.UpdateReport(-1 * total, -1 * numbers);
        }
    }
}