/*
 * @CreateTime: Aug 9, 2019 11:07 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 9, 2019 11:07 AM 
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.Procurment;

namespace BionicERP.Application.Procurment.PurchaseOrders.Models {
    public class PurchaseOrderView {
        private decimal _totalCost = 0;
        private float? _tax = 0;
        private float? _discount = 0;
        public uint Id { get; set; }
        public uint VendorId { get; set; }
        public string Vendor { get; set; }
        public string Status { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? OrderedDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public float? Tax {
            get {
                return _tax;
            }
            set {
                _tax = value == null ? 0 : value;
            }
        }
        public decimal TotalCost {
            get {
                return (_totalCost - (_totalCost * (decimal) (Tax / 100 + Discount / 100))) + (decimal) AdditionalFee;
            }
            set {
                _totalCost = value;
            }
        }
        public float? AdditionalFee { get; set; }
        public float? Discount {
            get {
                return _discount;
            }
            set {
                _discount = value == null ? 0 : value;
            }
        }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string OrderId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }

        public static Expression<Func<PurchaseOrder, PurchaseOrderView>> Projection {

            get {
                return po => new PurchaseOrderView () {
                    Id = po.Id,
                    Vendor = po.Vendor.Name,
                    VendorId = po.VendorId,
                    Status = po.Status,
                    ExpectedDate = po.ExpectedDate,
                    OrderedDate = po.OrderedDate,
                    ShippedDate = po.ShippedDate,
                    Tax = po.Tax,
                    TotalCost = (po.StockBatch.Count != 0) ?
                    (decimal) po.StockBatch.Sum (item => item.UnitCost * item.Quantity) :
                    (decimal) po.PurchaseOrderQuotation.Sum (item => item.UnitPrice * item.Quantity),
                    DateAdded = po.DateAdded,
                    DateUpdated = po.DateUpdated,
                    Discount = po.Discount,
                    OrderId = po.OrderId,
                    PaymentDate = po.PaymentDate,
                    InvoiceDate = po.InvoiceDate,
                    InvoiceId = po.InvoiceId,
                    AdditionalFee = po.AdditionalFee
                };
            }
        }

        public static PurchaseOrderView Create (PurchaseOrder purchaseOrder) {
            return Projection.Compile ().Invoke (purchaseOrder);
        }

    }
}