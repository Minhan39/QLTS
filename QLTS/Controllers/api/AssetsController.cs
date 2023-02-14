using Microsoft.AspNetCore.Mvc;
using QLTS.Models;
using QLTS.Models.AssetModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QLTS.Controllers.api
{
    [Produces("application/json")]
    [System.Web.Http.Route("api/Assets")]
    public class AssetsController : ApiController
    {
        private QLTS_DBEntities db = new QLTS_DBEntities();
        [System.Web.Http.Route("~/api/Assets")]
        [System.Web.Http.HttpGet]
        public List<AssetModel> Index()
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
        [System.Web.Http.Route("~/api/Assets/{id}")]
        [System.Web.Http.HttpGet]
        public AssetModel Get(int id)
        {
            return (AssetModel)Index().Find(n => n.Id == id);
        }
    }
}