/*
 * @CreateTime: Aug 24, 2019 5:06 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 5:07 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.StockBatchs.Models {
    public class StockBatchViewModel {
        public uint Id { get; set; }
        public uint LotId { get; set; }
        public uint ItemId { get; set; }
        public string Item { get; set; }
        public uint? ManufactureOrderId { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public DateTime AvailableFrom { get; set; }
        public float Quantity { get; set; }
        public float UnitCost { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? ArrivalDate { get; set; }

        public static Expression<Func<StockBatchStorage, StockBatchViewModel>> Projection {
            get {
                return lot => new StockBatchViewModel () {
                    Id = lot.Id,
                    LotId = lot.BatchId,
                    ItemId = lot.Batch.ItemId,
                    Item = lot.Batch.Item.Name,
                    ManufactureOrderId = lot.Batch.ManufactureOrderId,
                    PurchaseOrderId = lot.Batch.PurchaseOrderId,
                    AvailableFrom = lot.Batch.AvailableFrom,
                    Quantity = lot.Quantity,
                    UnitCost = lot.Batch.UnitCost,
                    Status = lot.Batch.Status,
                    Source = lot.Batch.Source,
                    ExpiryDate = lot.Batch.ExpiryDate,
                    ArrivalDate = lot.Batch.ArrivalDate,
                    DateAdded = lot.DateAdded,
                    DateUpdated = lot.DateUpdated

                };
            }
        }

        public StockBatchViewModel create (StockBatchStorage lot) {
            return Projection.Compile ().Invoke (lot);
        }
    }
}