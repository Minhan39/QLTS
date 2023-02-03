using QLTS.Models.AssetModel;
using QLTS.Models.RoomModel;
using QLTS.Models.UnitModel;
using System;

namespace QLTS.Models.AssetAllocationModel
{
    public class AssetAllocationModel
    {
        public int Id { get; set; }
        public int AssetId
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
        public int RoomId
        {
            get
            {
                return (Room != null) ? Room.Id : -1;
            }
            set
            {
                Room = RoomHelper.GetRoomsNotJoin().Find(n => n.Id == value);
            }
        }
        public Room Room { get; private set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> UnitId
        {
            get
            {
                return (Unit != null) ? Unit.Id : -1;
            }
            set
            {
                Unit = UnitHelper.GetUnits().Find(n => n.Id == value);
            }
        }
        public Unit Unit { get; private set; }
        public Nullable<System.DateTime> AtAllocation { get; set; }
        public Nullable<System.DateTime> AtEndAllocation { get; set; }
        public Nullable<System.DateTime> AtScheduledEndAllocation { get; set; }
        public Nullable<System.DateTime> AtCreate { get; set; }
        public Nullable<System.DateTime> AtUpdate { get; set; }
    }
}