using System.Collections.Generic;

namespace QLTS.Models.DeviceErrorReportModel
{
    public class DeviceErrorReportStatusHelper
    {
        public static List<string> GetStatus()
        {
            List<string> list = new List<string>();
            list.Add("Không hoạt động");
            list.Add("Hoạt động chậm");
            list.Add("Không có thiết bị");
            list.Add("Mất thiết bị");
            list.Add("Không rõ tình trạng");
            return list;
        }
    }
}