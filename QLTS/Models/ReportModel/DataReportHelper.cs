using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.ReportModel
{
    public class DataReportHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        private static DateTime current = DateTime.Now;
        private static string reportId = $"D{current.Month:D2}{current.Year}";
        private static List<Report> reports = db.Reports.ToList();
        private static List<ReportCategory> reportCategories = db.ReportCategories.ToList();
        private static List<Category> categories = db.Categories.ToList();
        /// <summary>
        /// Nếu giá trị âm được truyền vào, trị tuyệt đối của nó sẽ thêm vào *Giá trị giảm.
        /// Ngược lại, nó sẽ được thêm vào *Giá trị tăng
        /// </summary>
        /// <param name="total"></param>
        /// <param name="numbers"></param>
        public static void UpdateReport(decimal total, int numbers)
        {
            Report report = reports.FirstOrDefault(n => n.ReportId == reportId);
            if (report == null) return;

            report.TotalIncrease += Math.Max(total, 0);
            report.TotalDecrease += Math.Max(-1 * total, 0);
            report.NumberIncrease += Math.Max(numbers, 0);
            report.NumberDecrease += Math.Max(-1 * numbers, 0);
            db.SaveChanges();
        }
        /// <summary>
        /// Nếu giá trị âm được truyền vào, trị tuyệt đối của nó sẽ thêm vào *Giá trị giảm.
        /// Ngược lại, nó sẽ được thêm vào *Giá trị tăng
        /// </summary>
        /// <param name="total"></param>
        /// <param name="numbers"></param>
        public static void UpdateReportCategory(decimal total, int numbers, int? categoryId)
        {
            Category category = categories.FirstOrDefault(n => n.Id == categoryId);
            while (category?.Name != "ROOT")
            {
                string id = reportId + "C" + category.Id.ToString();
                ReportCategory report = reportCategories.FirstOrDefault(n => n.ReportId == id);
                if (report != null)
                {
                    report.TotalIncrease += Math.Max(total, 0);
                    report.TotalDecrease += Math.Max(-1 * total, 0);
                    report.NumberIncrease += Math.Max(numbers, 0);
                    report.NumberDecrease += Math.Max(-1 * numbers, 0);

                    category = categories.FirstOrDefault(n => n.Id == category.ParentId);
                }
            }
            db.SaveChanges();
        }
        /// <summary>
        /// Nếu giá trị âm được truyền vào, trị tuyệt đối của nó sẽ thêm vào *Giá trị giảm.
        /// Ngược lại, nó sẽ được thêm vào *Giá trị tăng
        /// </summary>
        /// <param name="total"></param>
        /// <param name="numbers"></param>
        public static void UpdateReportCategory(decimal oldTotal, decimal newTotal, int oldNumbers, int newNumbers, int? oldCategoryId, int? newCategoryId)
        {
            if (oldCategoryId == newCategoryId)
            {
                UpdateReportCategory(newTotal, newNumbers, newCategoryId);
                return;
            }
            Category category = categories.FirstOrDefault(n => n.Id == newCategoryId);
            while (category?.Name != "ROOT")
            {
                string id = reportId + "C" + category.Id.ToString();
                ReportCategory report = reportCategories.FirstOrDefault(n => n.ReportId == id);
                if (report != null)
                {
                    report.TotalIncrease += Math.Max(newTotal, 0);
                    report.TotalDecrease += Math.Max(-1 * newTotal, 0);
                    report.NumberIncrease += Math.Max(newNumbers, 0);
                    report.NumberDecrease += Math.Max(-1 * newNumbers, 0);

                    category = categories.FirstOrDefault(n => n.Id == category.ParentId);
                }                
            }
            category = categories.FirstOrDefault(n => n.Id == oldCategoryId);
            while (category?.Name != "ROOT")
            {
                string id = reportId + "C" + category.Id.ToString();
                ReportCategory report = reportCategories.FirstOrDefault(n => n.ReportId == id);
                if (report != null)
                {
                    report.TotalIncrease += Math.Max(oldTotal, 0);
                    report.TotalDecrease += Math.Max(-1 * oldTotal, 0);
                    report.NumberIncrease += Math.Max(oldNumbers, 0);
                    report.NumberDecrease += Math.Max(-1 * oldNumbers, 0);

                    category = categories.FirstOrDefault(n => n.Id == category.ParentId);
                }
            }
            db.SaveChanges();
        }
    }
}