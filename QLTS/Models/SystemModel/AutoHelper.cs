using System;
using System.Linq;

namespace QLTS.Models.SystemModel
{
    public class AutoHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static void AddNewRecordReportAtBegingOfMonth()
        {
            DateTime current = DateTime.Now;
            if (current.Day != 1) return;
            string reportId = "D" + ((current.Month < 10) ? "0" : "") + current.Month.ToString() + current.Year.ToString();
            var reports = db.Reports;
            var reportCategories = db.ReportCategories;
            var reportStatus = db.ReportStatus;

            if (reports.Any(n => n.ReportId == reportId)) return;

            Report oldReport = reports.OrderByDescending(x => x.ReportId).FirstOrDefault();
            Report report = new Report
            {
                ReportId = reportId,
                Total = (oldReport != null) ? oldReport.Total + oldReport.TotalIncrease - oldReport.TotalDecrease : 0,
                Numbers = (oldReport != null) ? oldReport.Numbers + oldReport.NumberIncrease - oldReport.NumberDecrease : 0,
                TotalIncrease = 0,
                NumberIncrease = 0,
                TotalDecrease = 0,
                NumberDecrease = 0
            };
            reports.Add(report);

            var categories = CategoryModel.CategoryHelper.GetCategoriesNotJoin();
            int rootId = categories.Find(n => n.Name == "ROOT").Id;
            categories = categories.Where(n => n.Name != "ROOT").ToList();
            foreach (Category item in categories)
            {
                string categoryId = "C" + item.Id.ToString();
                string reportIdCategory = reportId + categoryId;
                ReportCategory oldReportCategory = reportCategories.OrderByDescending(x => x.ReportId).FirstOrDefault(n => n.ReportId.Contains(categoryId));
                ReportCategory reportCategory = new ReportCategory
                {
                    ReportId = reportIdCategory,
                    Total = (oldReportCategory != null) ? oldReportCategory.Total + oldReportCategory.TotalIncrease - oldReportCategory.TotalDecrease : 0,
                    Numbers = (oldReportCategory != null) ? oldReportCategory.Numbers + oldReportCategory.NumberIncrease - oldReportCategory.NumberDecrease : 0,
                    TotalIncrease = 0,
                    NumberIncrease = 0,
                    TotalDecrease = 0,
                    NumberDecrease = 0,
                    CategoryName = item.Name,
                    IsFirstClassCategory = item.ParentId == rootId ? true : false
                };
                reportCategories.Add(reportCategory);
            }

            var statuses = AssetStatusHelper.GetStatus();
            foreach (AssetStatusModel item in statuses)
            {
                string statusId = "S" + item.Id.ToString();
                string reportIdStatus = reportId + statusId;
                ReportStatu oldReportStatus = reportStatus.OrderByDescending(x => x.ReportId).FirstOrDefault(n => n.ReportId.Contains(statusId));
                ReportStatu reportStatu = new ReportStatu
                {
                    ReportId = reportIdStatus,
                    Total = (oldReportStatus != null) ? oldReportStatus.Total + oldReportStatus.TotalIncrease - oldReportStatus.TotalDecrease : 0,
                    Numbers = (oldReportStatus != null) ? oldReportStatus.Numbers + oldReportStatus.NumberIncrease - oldReportStatus.NumberDecrease : 0,
                    TotalIncrease = 0,
                    NumberIncrease = 0,
                    TotalDecrease = 0,
                    NumberDecrease = 0,
                    StatusName = item.Name
                };
                reportStatus.Add(reportStatu);
            }

            db.SaveChanges();
        }
    }
}