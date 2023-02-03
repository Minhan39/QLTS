using System.Collections.Generic;

namespace QLTS.Models.RepairModel
{
    public class RepairTypeHelper
    {
        public static List<string> GetTypes()
        {
            List<string> data = new List<string>();
            data.Add("Sửa chữa");
            data.Add("Bảo trì");
            data.Add("Bảo dưỡng");
            return data;
        }
    }
}