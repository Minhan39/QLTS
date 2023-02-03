using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.DeviceErrorReportModel
{
    public class DeviceErrorReportHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<DeviceErrorReportModel> GetDeviceErrorReports()
        {
            db.DeviceErrorReports.Where(n => n.AtReciver == null).ToList().ForEach(n => n.AtReciver = DateTime.Now);
            db.SaveChanges();
            return db.DeviceErrorReports.OrderBy(i => i.AtReport).Where(n => n.AtHandler == null || n.AtHandler >= DateTime.Now).Select(n => new DeviceErrorReportModel { 
                Id = n.Id,
                AssetId = n.AssetId,
                Message = n.Message,
                Status = n.Status,
                HandlerId = n.HandlerId,
                AtHandler = n.AtHandler,
                AtReciver = n.AtReciver,
                AtReport = n.AtReport,
                AtCreate = n.AtCreate,
                AtUpdate = n.AtUpdate
            }).ToList();
        }
        public static List<DeviceErrorReport> GetDeviceErrorReportsNotJoin()
        {
            return db.DeviceErrorReports.ToList();
        }
        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        public static void AddNewRecord(DeviceErrorReport deviceErrorReport)
        {
            deviceErrorReport.AtCreate = DateTime.Now;
            deviceErrorReport.AtReport = DateTime.Now;
            db.DeviceErrorReports.Add(deviceErrorReport);
            db.SaveChanges();
        }

        public static void UpdateRecord(DeviceErrorReport deviceErrorReport)
        {
            DeviceErrorReport item = db.DeviceErrorReports.Find(deviceErrorReport.Id);
            item.AssetId = deviceErrorReport.AssetId;
            item.HandlerId = deviceErrorReport.HandlerId;
            item.AtHandler = deviceErrorReport.AtHandler;
            item.AtUpdate = DateTime.Now;
            db.SaveChanges();
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<DeviceErrorReport> deviceErrorReports = GetDeviceErrorReportsNotJoin().Where(i => selectedIds.Contains(i.Id));
            db.DeviceErrorReports.RemoveRange(deviceErrorReports);
            db.SaveChanges();
        }
    }
}