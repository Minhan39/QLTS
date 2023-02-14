namespace QLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeviceErrorReport")]
    public partial class DeviceErrorReport
    {
        public int Id { get; set; }

        public int? AssetId { get; set; }

        public string Message { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int? HandlerId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtReport { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtReciver { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtHandler { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtCreate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtUpdate { get; set; }
    }
}
