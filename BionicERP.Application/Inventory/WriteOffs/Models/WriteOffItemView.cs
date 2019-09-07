using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.WriteOffs.Models {
    public class WriteOffItemView {
        private float _batchQuantity = 0;
        private float _quantity = 0;
        private float _unitCost = 0;
        public uint Id { get; set; }
        public uint BatchStorageId { get; set; }
        public uint BatchId { get; set; }
        public string Storage { get; set; }

        public uint StorageId { get; set; }
        public string Item { get; set; }
        public string Uom { get; set; }
        public string BatchStatus { get; set; }
        public float TotalBooked { get; set; }
        public uint ItemId { get; set; }
        public uint WriteOffId { get; set; }

        public float TotalCost { get; set; }
        public float UnitCost {
            get {
                return _unitCost;
            }
            set {
                _unitCost = value;
                calculateTotalCost ();
            }
        }

        public float BatchQuantity {
            get {
                return _batchQuantity;
            }
            set {
                _batchQuantity = value;
            }
        }
        public float Quantity {
            get {
                return _quantity;
            }
            set {
                _quantity = value;
                calculateTotalCost ();
            }
        }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        private void calculateTotalCost () {
            TotalCost = UnitCost * Quantity;
        }

        public static Expression<Func<WriteOffDetail, WriteOffItemView>> Projection {
            get {
                return writeoff_detail => new WriteOffItemView () {
                    Id = writeoff_detail.Id,
                    BatchId = writeoff_detail.BatchStorage.BatchId,
                    BatchStatus = writeoff_detail.BatchStorage.Batch.Status,
                    BatchStorageId = writeoff_detail.BatchStorageId,
                    Storage = writeoff_detail.BatchStorage.Storage.Name,
                    StorageId = writeoff_detail.BatchStorage.StorageId,
                    Item = writeoff_detail.BatchStorage.Batch.Item.Name,
                    Uom = writeoff_detail.BatchStorage.Batch.Item.PrimaryUom.Name,
                    ItemId = writeoff_detail.BatchStorage.Batch.ItemId,
                    WriteOffId = writeoff_detail.WriteOffId,
                    Quantity = writeoff_detail.Quantity,
                    BatchQuantity = writeoff_detail.BatchStorage.Quantity,
                    UnitCost = writeoff_detail.BatchStorage.Batch.UnitCost,
                    DateAdded = writeoff_detail.DateAdded,
                    DateUpdated = writeoff_detail.DateUpdated
                };
            }
        }

        public static WriteOffItemView create (WriteOffDetail writeoff_detail) {
            return Projection.Compile ().Invoke (writeoff_detail);
        }

    }
}