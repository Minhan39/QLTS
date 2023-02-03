using System;

namespace QLTS.Models.RoomModel
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Floor { get; set; }
        public Nullable<int> AreaId { get; set; }
        public Area Area { get; set; }
        public Nullable<System.DateTime> AtCreate { get; set; }
        public Nullable<System.DateTime> AtUpdate { get; set; }
    }
}