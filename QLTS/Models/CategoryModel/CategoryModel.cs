using System;

namespace QLTS.Models.CategoryModel
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public Category CategoryParent { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<System.DateTime> AtCreate { get; set; }
        public Nullable<System.DateTime> AtUpdate { get; set; }
    }
}