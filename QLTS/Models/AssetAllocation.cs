namespace QLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssetAllocation")]
    public partial class AssetAllocation
    {
        public int Id { get; set; }

        public int AssetId { get; set; }

        public int RoomId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Amount { get; set; }

        public int? UnitId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtAllocation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtEndAllocation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtScheduledEndAllocation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtCreate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtUpdate { get; set; }
    }
}
