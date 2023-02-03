using DevExpress.Web.Mvc;
using QLTS.Models.AssetModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.CategoryModel
{
    public class CategoryHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<CategoryModel> GetCategories()
        {
            Category category = db.Categories.FirstOrDefault(n => n.Name == "ROOT");
            if (category == null)
            {
                Category root = new Category()
                {
                    Name = "ROOT",
                    ParentId = -1,
                };
                db.Categories.Add(root);
                db.SaveChanges();
            }
            List<CategoryModel> list = db.Categories.Join(db.Categories, a => a.ParentId, b => b.Id, (a, b) => new CategoryModel
            {
                Id = a.Id,
                CategoryId = a.CategoryId,
                Name = a.Name,
                ParentId = a.ParentId,
                AtCreate = a.AtCreate,
                AtUpdate = a.AtUpdate,
                CategoryParent = b
            }).Where(n => n.Name != "ROOT").ToList();
            return list;
        }
        public static List<Category> GetCategoriesNotJoin()
        {
            return db.Categories.OrderBy(n => n.Name).ToList();
        }
        //Kiểm tra tồn tại các danh mục con và các tài sản thuộc phân loại
        public static bool Validation(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<Category> categories = GetCategoriesNotJoin().Where(i => selectedIds.Contains((int)i.ParentId));
            if (categories.Count() > 0)
            {
                return false;
            }
            IEnumerable<Asset> assets = AssetHelper.GetAssetsNotJoin().Where(i => selectedIds.Contains((int)i.CategoryId));
            if (assets.Count() > 0)
            {
                return false;
            }
            return true;
        }
        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        public static void AddNewRecord(Category category)
        {
            category.AtCreate = DateTime.Now;
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public static void UpdateRecord(Category category)
        {
            Category item = db.Categories.Find(category.Id);
            item.Name = category.Name;
            item.CategoryId = category.CategoryId;
            item.ParentId = category.ParentId;
            item.AtUpdate = DateTime.Now;
            db.SaveChanges();
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<Category> categories = GetCategoriesNotJoin().Where(i => selectedIds.Contains(i.Id));
            db.Categories.RemoveRange(categories);
            db.SaveChanges();
        }
    }
}