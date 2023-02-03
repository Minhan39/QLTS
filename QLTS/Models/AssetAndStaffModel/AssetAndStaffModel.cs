using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTS.Models.AssetAndStaffModel
{
    public class AssetAndStaffModel
    {
        public int AssetId { get; set; }
        public int ManagerId { get; set; }
        public Nullable<DateTime> AtStart { get; set; }
        public Nullable<DateTime> AtEnd { get; set; }
    }
}