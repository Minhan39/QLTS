namespace QLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report
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
    }
}
