namespace QLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ManagementAssignment")]
    public partial class ManagementAssignment
    {
        public int Id { get; set; }

        public int ManagerId { get; set; }

        public int RoomId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtAssignment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtEndAssignment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtScheduledEndAssignment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtCreate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AtUpdate { get; set; }
    }
}
