using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        }

        public static void UpdateRecord(Asset asset)
        {
            Asset item = db.Assets.Find(asset.Id);
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
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<Asset> assets = GetAssetsNotJoin().Where(i => selectedIds.Contains(i.Id));
            db.Assets.RemoveRange(assets);
            db.SaveChanges();
        }
    }
}