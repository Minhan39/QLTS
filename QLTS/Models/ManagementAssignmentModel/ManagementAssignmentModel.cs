using QLTS.Models.RoomModel;
using QLTS.Models.StaffModel;
using System;

namespace QLTS.Models.ManagementAssignmentModel
{
    public class ManagementAssignmentModel
    {
        public int Id { get; set; }
        public int ManagerId
        {
            get
            {
                return (Staff != null) ? Staff.Id : -1;
            }
            set
            {
                Staff = StaffHelper.GetStaffs().Find(n => n.Id == value);
            }
        }
        public Staff Staff { get; private set; }
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
        public Nullable<System.DateTime> AtAssignment { get; set; }
        public Nullable<System.DateTime> AtEndAssignment { get; set; }
        public Nullable<System.DateTime> AtScheduledEndAssignment { get; set; }
        public Nullable<System.DateTime> AtCreate { get; set; }
        public Nullable<System.DateTime> AtUpdate { get; set; }
    }
}