using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.ManagementAssignmentModel
{
    public class ManagementAssignmentHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<ManagementAssignmentModel> GetManagementAssignments()
        {
            //Kiểm tra và xoá các phân công hết hạn
            List<ManagementAssignment> removeList = db.ManagementAssignments.Where(n => n.AtEndAssignment <= DateTime.Now).ToList();
            db.ManagementAssignments.RemoveRange(removeList);
            db.SaveChanges();

            List<ManagementAssignmentModel> list = db.ManagementAssignments.Select(n => new ManagementAssignmentModel
            {
                Id = n.Id,
                ManagerId = n.ManagerId,
                RoomId = n.RoomId,
                AtAssignment = n.AtAssignment,
                AtEndAssignment = n.AtEndAssignment,
                AtScheduledEndAssignment = n.AtScheduledEndAssignment,
                AtCreate = n.AtCreate,
                AtUpdate = n.AtUpdate
            }).ToList();
            return list;
        }
        public static List<ManagementAssignment> GetManagementAssignmentsNotJoin()
        {
            return db.ManagementAssignments.OrderBy(i => i.Id).ToList();
        }
        //Kiểm tra quản lý của phòng
        public static bool Validation(long roomId)
        {
            return (db.ManagementAssignments.FirstOrDefault(n => n.RoomId == roomId) == null) ? true : false;
        }
        //Kiểm tra quản lý của phòng khi chỉnh sửa
        public static bool Validation(long roomId, long Id)
        {
            return (db.ManagementAssignments.FirstOrDefault(n => n.RoomId == roomId && n.Id != Id) == null) ? true : false;
        }
        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        public static void AddNewRecord(ManagementAssignment managementAssignment)
        {
            managementAssignment.AtCreate = DateTime.Now;
            db.ManagementAssignments.Add(managementAssignment);
            db.SaveChanges();
        }

        public static void UpdateRecord(ManagementAssignment managementAssignment)
        {
            ManagementAssignment item = db.ManagementAssignments.Find(managementAssignment.Id);
            item.ManagerId = managementAssignment.ManagerId;
            item.RoomId = managementAssignment.RoomId;
            item.AtAssignment = managementAssignment.AtAssignment;
            item.AtEndAssignment = managementAssignment.AtEndAssignment;
            item.AtScheduledEndAssignment = managementAssignment.AtScheduledEndAssignment;
            item.AtUpdate = DateTime.Now;
            db.SaveChanges();
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<ManagementAssignment> managementAssignments = GetManagementAssignmentsNotJoin().Where(i => selectedIds.Contains(i.Id));
            db.ManagementAssignments.RemoveRange(managementAssignments);
            db.SaveChanges();
        }
    }
}