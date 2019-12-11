using System;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.Procurment;

namespace BionicERP.Application.Procurment.PurchaseOrders.Models {
    public class PurchaseOrderIndexModel {
        public uint Id { get; set; }
        public string Vendor { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal? TotalAmount { get; set; }

        public decimal? RemainingAmount {
            get {
                return (decimal?) TotalAmount - (decimal?) PaidAmount;
            }
            set { }
        }

        public static Expression<Func<PurchaseOrder, PurchaseOrderIndexModel>> Projection {
            get {
                return po => new PurchaseOrderIndexModel () {
                    Id = po.Id,
                    Vendor = po.Vendor.Name
                };
            }
        }

        public static Expression<Func<PurchaseOrder, PurchaseOrderIndexModel>> Balance {
            get {
                return po => new PurchaseOrderIndexModel () {
                    Id = po.Id,
                    Vendor = $"PO-{po.Id}  {po.Vendor.Name}",
                    PaidAmount = (decimal) po.InvoicePayments.Sum (p => (decimal) p.Amount),
                    TotalAmount = (decimal?) po.StockBatch.Sum (p => (double) p.UnitCost * (double) p.Quantity)

                };
            }
        }
    }
}