using System.Collections.Generic;

namespace QLTS.Models.SystemModel
{
    public class AssetStatusHelper
    {
        public static List<AssetStatusModel> GetStatus()
        {
            List<AssetStatusModel> list = new List<AssetStatusModel>();
            list.Add(new AssetStatusModel(1, "Sử dụng"));
            list.Add(new AssetStatusModel(2, "Đang sử chữa"));
            list.Add(new AssetStatusModel(3, "Hư hỏng"));
            list.Add(new AssetStatusModel(4, "Cần thanh lý"));
            return list;
        }
    }
}