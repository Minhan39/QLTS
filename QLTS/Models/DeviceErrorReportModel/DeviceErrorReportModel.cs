using System;
using QLTS.Models.AssetModel;
using QLTS.Models.StaffModel;

namespace QLTS.Models.DeviceErrorReportModel
{
    public class DeviceErrorReportModel
    {
        public int Id { get; set; }
        public Nullable<int> AssetId
        {
            get
            {
                return (Asset != null) ? Asset.Id : -1;
            }
            set
            {
                Asset = AssetHelper.GetAssetsNotJoin().Find(n => n.Id == value);
            }
        }
        public Asset Asset { get; private set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public Nullable<int> HandlerId
        {
            get
            {
                return (Handler != null) ? Handler.Id : -1;
            }
            set
            {
                Handler = StaffHelper.GetStaffs().Find(n => n.Id == value);
            }
        }
        public Staff Handler { get; private set; }
        public Nullable<System.DateTime> AtReport { get; set; }
        public Nullable<System.DateTime> AtReciver { get; set; }
        public Nullable<System.DateTime> AtHandler { get; set; }
        public Nullable<System.DateTime> AtCreate { get; set; }
        public Nullable<System.DateTime> AtUpdate { get; set; }
    }
}