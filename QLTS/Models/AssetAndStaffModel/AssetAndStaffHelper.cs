using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.AssetAndStaffModel
{
    public class AssetAndStaffHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<AssetAndStaffModel> GetAssetAndStaffs()
        {
            return db.AssetAllocations.Join(db.ManagementAssignments, a => a.RoomId, m => m.RoomId, (a,m) => new AssetAndStaffModel { 
                AssetId = a.AssetId,
                ManagerId = m.ManagerId,
                AtStart = (a.AtAllocation >= m.AtAssignment) ? a.AtAllocation : m.AtAssignment,
                AtEnd = ((a.AtEndAllocation != null && m.AtEndAssignment == null) || (a.AtEndAllocation != null && m.AtEndAssignment != null && a.AtEndAllocation < m.AtEndAssignment)) ? a.AtEndAllocation : m.AtEndAssignment
            }).ToList();
        }
    }
}