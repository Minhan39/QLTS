using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.StaffModel
{
    public class StaffHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<Staff> GetStaffs()
        {
            return db.Staffs.OrderBy(n => n.Name).ToList();
        }
    }
}