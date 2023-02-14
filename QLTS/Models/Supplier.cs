namespace QLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string SupplierId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string GroupI { get; set; }

        [StringLength(15)]
        public string TaxCode { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(12)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string LinkWebsite { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        [StringLength(50)]
        public string Ward { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(15)]
        public string BusinessRegistrationCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtCreate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtUpdate { get; set; }
    }
}
