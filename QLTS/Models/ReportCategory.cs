namespace QLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReportCategory")]
    public partial class ReportCategory
    {
        public int Id { get; set; }

        [StringLength(12)]
        public string ReportId { get; set; }

        public decimal? Total { get; set; }

        public int? Numbers { get; set; }

        public decimal? TotalIncrease { get; set; }

        public int? NumberIncrease { get; set; }

        public decimal? TotalDecrease { get; set; }

        public int? NumberDecrease { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        public bool? IsFirstClassCategory { get; set; }
    }
}
