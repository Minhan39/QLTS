using DevExpress.Web.Mvc;
using QLTS.Models.AssetModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTS.Models.AssetAllocationModel
{
    public class AssetAllocationHelper
    {
        private static QLTS_DBEntities db = new QLTS_DBEntities();
        public static List<AssetAllocationModel> GetAssetAllocations()
        {
            //Kiểm tra và xoá các phân bổ hết hạn
            List<AssetAllocation> removeList = db.AssetAllocations.Where(n => n.AtEndAllocation <= DateTime.Now).ToList();
            db.AssetAllocations.RemoveRange(removeList);
            db.SaveChanges();

            List<AssetAllocationModel> list = db.AssetAllocations.Select(n => new AssetAllocationModel
            {
                Id = n.Id,
                AssetId = n.AssetId,
                RoomId = n.RoomId,
                Quantity = n.Quantity,
                Amount = n.Amount,
                UnitId = n.UnitId,
                AtAllocation = n.AtAllocation,
                AtEndAllocation = n.AtEndAllocation,
                AtScheduledEndAllocation = n.AtScheduledEndAllocation,
                AtCreate = n.AtCreate,
                AtUpdate = n.AtUpdate
            }).ToList();
            return list;
        }
        public static List<AssetAllocation> GetAssetAllocationsNotJoin()
        {
            return db.AssetAllocations.OrderBy(i => i.Id).ToList();
        }
        //Kiểm tra số lượng chênh lệch
        public static bool Validation(long assetId, long quantity)
        {
            var query = db.AssetAllocations.Where(n => n.AssetId == assetId).Select(n => n.Quantity).Sum();
            long sum = (query != null) ? (long)query : 0;
            long root = (long)AssetHelper.GetAssetsNotJoin().Find(n => n.Id == assetId).Quantity;
            return (root - sum >= quantity) ? true : false;
        }
        //Kiểm tra số lượng chện lệch khi chỉnh sửa (đã tồn tài tài sản này tại phòng muốn phân công)
        public static bool Validation(long assetId, long quantity, long roomId)
        {
            var query = db.AssetAllocations.Where(n => n.AssetId == assetId && n.RoomId != roomId).Select(n => n.Quantity).Sum();
            long sum = (query != null) ? (long)query : 0;
            long root = (long)AssetHelper.GetAssetsNotJoin().Find(n => n.Id == assetId).Quantity;
            return (root - sum >= quantity) ? true : false;
        }
        public static GridViewModel GetGridViewModel()
        {
            return new GridViewModel();
        }
        public static void AddNewRecord(AssetAllocation assetAllocation)
        {
            AssetAllocation exist = db.AssetAllocations.FirstOrDefault(n => n.RoomId == assetAllocation.RoomId && n.AssetId == assetAllocation.AssetId);
            //Kiểm tra tồn tại tài sản trong phòng, nếu có tồn tại thì chỉ tăng số lượng
            if (exist != null)
            {
                exist.Quantity += assetAllocation.Quantity;
                Asset asset = db.Assets.Find(exist.AssetId);
                exist.UnitId = asset.UnitId;
                exist.Amount = asset.Amount;
                exist.AtUpdate = DateTime.Now;
            }
            else
            {
                assetAllocation.AtCreate = DateTime.Now;
                Asset asset = db.Assets.Find(assetAllocation.AssetId);
                assetAllocation.UnitId = asset.UnitId;
                assetAllocation.Amount = asset.Amount;
                db.AssetAllocations.Add(assetAllocation);
            }
            db.SaveChanges();
        }

        public static void UpdateRecord(AssetAllocation assetAllocation)
        {
            //Kiểm tra số lượng cập nhật tài sản > 0, <= 0 sẽ xoá phân bổ
            if (assetAllocation.Quantity > 0)
            {
                AssetAllocation item = db.AssetAllocations.Find(assetAllocation.Id);
                Asset asset = db.Assets.Find(assetAllocation.AssetId);
                item.AssetId = assetAllocation.AssetId;
                item.RoomId = assetAllocation.RoomId;
                item.Quantity = assetAllocation.Quantity;
                item.Amount = asset.Amount;
                item.UnitId = asset.UnitId;
                item.AtAllocation = assetAllocation.AtAllocation;
                item.AtEndAllocation = assetAllocation.AtEndAllocation;
                item.AtScheduledEndAllocation = assetAllocation.AtScheduledEndAllocation;
                item.AtUpdate = DateTime.Now;
            }
            else
            {
                db.AssetAllocations.Remove(db.AssetAllocations.Find(assetAllocation.Id));
            }
            db.SaveChanges();
        }

        public static void DeleteRecords(string selectedRowIds)
        {
            List<int> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(id => int.Parse(id));
            IEnumerable<AssetAllocation> assetAllocations = GetAssetAllocationsNotJoin().Where(i => selectedIds.Contains(i.Id));
            db.AssetAllocations.RemoveRange(assetAllocations);
            db.SaveChanges();
        }
    }
}