namespace QLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Repair")]
    public partial class Repair
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string InvoiceCode { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Traders { get; set; }

        [StringLength(50)]
        public string SupplierName { get; set; }

        [StringLength(100)]
        public string SupplierAddress { get; set; }

        [StringLength(12)]
        public string SupplierPhone { get; set; }

        [StringLength(12)]
        public string SupplierFax { get; set; }

        [StringLength(50)]
        public string SupplierMail { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtRepair { get; set; }

        public int? RepairTime { get; set; }

        public string Note { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtCreate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtUpdate { get; set; }

        public int AssetId { get; set; }
    }
}
