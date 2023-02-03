using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.UnitModel
{
    public class UnitHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<Unit> GetUnits()
        {
            return db.Units.OrderBy(i => i.Name).ToList();
        }
    }
}