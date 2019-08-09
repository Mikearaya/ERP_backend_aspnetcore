/*
 * @CreateTime: Aug 9, 2019 11:08 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
* @Last Modified By:  Mikael Araya
* @Last Modified Time: Aug 9, 2019 11:14 AM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;
using BionicERP.Domain.Procurment;

namespace BionicERP.Application.Procurment.PurchaseOrders.Models {
    public class PurchaseOrderItemView {
        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public uint ItemId { get; set; }
        public IEnumerable<string> StorageLocation { get; set; }
        public uint LotId { get; set; }
        public uint StorageId { get; set; }
        public string Item { get; set; }
        public uint ItemGroupId { get; set; }
        public string ItemGroup { get; set; }
        public float Quantity { get; set; }
        public double SubTotal { get; set; }
        public float UnitPrice { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Status { get; set; }

        public static Expression<Func<StockBatch, PurchaseOrderItemView>> Projection {

            get {
                return po_item => new PurchaseOrderItemView () {
                    LotId = po_item.Id,
                    StorageLocation = po_item.StockBatchStorage.AsQueryable ().Select (s => s.Storage.Name),
                    StorageId = po_item.Item.DefaultStorageId,
                    PurchaseOrderId = (uint) po_item.PurchaseOrderId,
                    ItemId = po_item.ItemId,
                    Item = po_item.Item.Name,
                    Status = po_item.Status,
                    ItemGroupId = po_item.Item.GroupId,
                    ItemGroup = po_item.Item.Group.GroupName,
                    Quantity = po_item.Quantity,
                    UnitPrice = po_item.UnitCost,
                    SubTotal = (double) po_item.Quantity * po_item.UnitCost,
                    ExpectedDate = po_item.AvailableFrom,
                    DateAdded = po_item.DateAdded,
                    DateUpdated = po_item.DateUpdated
                };
            }
        }

        public static Expression<Func<PurchaseOrderQuotation, PurchaseOrderItemView>> QuotProjection {

            get {
                return po_item => new PurchaseOrderItemView () {
                    Id = po_item.Id,
                    PurchaseOrderId = (uint) po_item.PurchaseOrderId,
                    ItemId = po_item.ItemId,
                    Item = po_item.Item.Name,
                    ItemGroupId = po_item.Item.GroupId,
                    ItemGroup = po_item.Item.Group.GroupName,
                    Quantity = po_item.Quantity,
                    UnitPrice = po_item.UnitPrice,
                    SubTotal = (double) po_item.Quantity * po_item.UnitPrice,
                    ExpectedDate = po_item.ExpectedDate,
                    DateAdded = po_item.DateAdded,
                    DateUpdated = po_item.DateUpdated
                };
            }
        }

        public static PurchaseOrderItemView Create (StockBatch po_item) {
            return Projection.Compile ().Invoke (po_item);
        }
    }
}