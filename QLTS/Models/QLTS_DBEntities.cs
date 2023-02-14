using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLTS.Models
{
    public partial class QLTS_DBEntities : DbContext
    {
        public QLTS_DBEntities()
            : base("name=QLTS_DBEntities")
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<AssetAllocation> AssetAllocations { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DeviceErrorReport> DeviceErrorReports { get; set; }
        public virtual DbSet<ManagementAssignment> ManagementAssignments { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportCategory> ReportCategories { get; set; }
        public virtual DbSet<ReportStatu> ReportStatus { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .Property(e => e.AssetId)
                .IsUnicode(false);

            modelBuilder.Entity<Asset>()
                .Property(e => e.BarCode)
                .IsUnicode(false);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Number)
                .IsUnicode(false);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Serial)
                .IsUnicode(false);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Part)
                .IsUnicode(false);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Asset>()
                .Property(e => e.LicensePlate)
                .IsUnicode(false);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Wattage)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.WMax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.WMin)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Weight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.SpecificGravity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Length)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Width)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Height)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Radius)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Perimeter)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Area)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Fuel)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Asset>()
                .Property(e => e.Diesel)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AssetAllocation>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryId)
                .IsUnicode(false);

            modelBuilder.Entity<Repair>()
                .Property(e => e.InvoiceCode)
                .IsUnicode(false);

            modelBuilder.Entity<Repair>()
                .Property(e => e.SupplierPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Repair>()
                .Property(e => e.SupplierFax)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.ReportId)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Report>()
                .Property(e => e.TotalIncrease)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Report>()
                .Property(e => e.TotalDecrease)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ReportCategory>()
                .Property(e => e.ReportId)
                .IsUnicode(false);

            modelBuilder.Entity<ReportCategory>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ReportCategory>()
                .Property(e => e.TotalIncrease)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ReportCategory>()
                .Property(e => e.TotalDecrease)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ReportStatu>()
                .Property(e => e.ReportId)
                .IsUnicode(false);

            modelBuilder.Entity<ReportStatu>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ReportStatu>()
                .Property(e => e.TotalIncrease)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ReportStatu>()
                .Property(e => e.TotalDecrease)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Staff>()
                .Property(e => e.StaffId)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierId)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.TaxCode)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.LinkWebsite)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.BusinessRegistrationCode)
                .IsUnicode(false);
        }
    }
}
