using System;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.Items.Models {
    public class ItemReportListView {

        private float _totalWriteOff = 0;
        private float _quantity = 0;
        private float _totalCost = 0;
        private float _inStock = 0;
        public uint Id { get; set; }

        public string Item { get; set; }

        public string ItemCode { get; set; }

        public float InStock {
            get {
                return _inStock;
            }
            set {
                _inStock = value;
            }
        }
        public float Available {
            get {
                return InStock - Booked;
            }
            set { }
        }

        public float Booked { get; set; }

        public float TotalExpected { get; set; }
        public float TotalWriteOff {
            get {
                return _totalWriteOff;
            }
            set {
                _totalWriteOff = value;
            }
        }

        public float ExpectedAvailable {
            get {
                return TotalExpected - ExpectedBooked;
            }
            set { }
        }

        public float ExpectedBooked { get; set; }

        public float? MinimumQuantity { get; set; }
        public string PrimaryUom { get; set; }
        public uint PrimaryUomId { get; set; }

        public float TotalCost {
            get {
                return _totalCost;
            }
            set {
                _totalCost = value;
            }
        }
        public float averageCost {
            get {
                return (InStock != 0 || TotalExpected != 0) ? _totalCost / (InStock + TotalExpected) : 0;
            }
            set { }
        }

        public static Expression<Func<IGrouping<Item, ItemLotJoin>, ItemReportListView>> Projection {
            get {
                return report => new ItemReportListView () {
                    Id = report.Key.Id,
                    Item = report.Key.Name,
                    ItemCode = report.Key.Code,
                    MinimumQuantity = report.Key.MinimumQuantity,
                    //     primaryUom = report.Key.PrimaryUom.Abrivation,
                    //     primaryUomId = report.Key.PrimaryUomId,
                    Booked = report.Sum (b => b.Lot.Where (s => s.Batch.Status.ToUpper () == "RECIEVED").Sum (i => i.BookedStockBatch.Sum (a => a.Quantity))),
                    InStock = report.Sum (b => b.Lot.Where (s => s.Batch.Status.ToUpper () == "RECIEVED").Sum (i => i.Quantity)),
                    ExpectedBooked = report.Sum (b => b.Lot.Where (s => s.Batch.Status.ToUpper () == "PLANED").Sum (i => i.BookedStockBatch.Sum (a => a.Quantity))),
                    TotalExpected = report.Sum (b => b.Lot.Where (s => s.Batch.Status.ToUpper () == "PLANED").Sum (i => i.Quantity)),
                    TotalCost = report.Sum (b => b.Lot.Sum (i => i.Quantity * i.Batch.UnitCost)),
                };
            }
        }

    }
}