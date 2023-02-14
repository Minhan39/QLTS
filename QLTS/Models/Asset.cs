namespace QLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Asset")]
    public partial class Asset
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string AssetId { get; set; }

        [StringLength(20)]
        public string BarCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtImport { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int? Quantity { get; set; }

        public decimal? Amount { get; set; }

        public int? UnitId { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        public int? SupplierId { get; set; }

        public string Uses { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtBuy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtUsing { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtStopUsing { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtLiquidation { get; set; }

        [StringLength(4)]
        public string Number { get; set; }

        [StringLength(15)]
        public string Serial { get; set; }

        [StringLength(15)]
        public string Part { get; set; }

        [StringLength(15)]
        public string Model { get; set; }

        [StringLength(15)]
        public string LicensePlate { get; set; }

        public decimal? Wattage { get; set; }

        public decimal? WMax { get; set; }

        public decimal? WMin { get; set; }

        public decimal? Weight { get; set; }

        public decimal? SpecificGravity { get; set; }

        public decimal? Length { get; set; }

        public decimal? Width { get; set; }

        public decimal? Height { get; set; }

        public decimal? Radius { get; set; }

        public decimal? Perimeter { get; set; }

        public decimal? Area { get; set; }

        public string NoteSpecification { get; set; }

        public int? Maintenance { get; set; }

        public int? Accreditation { get; set; }

        public int? Inventory { get; set; }

        public int? Insurance { get; set; }

        public decimal? Fuel { get; set; }

        public decimal? Diesel { get; set; }

        public int? Tire { get; set; }

        public int? Battery { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtCreate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtUpdate { get; set; }

        public byte[] Image { get; set; }
    }
}
