/*
 * @CreateTime: Aug 9, 2019 11:55 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 1:55 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrders.Commands {
    public class CreatePurchaseOrderCommand : IRequest<uint> {
        public CreatePurchaseOrderCommand () {
            PurchaseOrderItems = new List<PurchaseOrderItem> ();
        }

        public uint VendorId { get; set; }
        public string Status { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? OrderedDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public float? Tax { get; set; }
        public float? AdditionalFee { get; set; }
        public float? Discount { get; set; }
        public string OrderId { get; set; }
        public DateTime? ArivalDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }

        public IEnumerable<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }

    public class PurchaseOrderItem {
        public uint? Id { get; set; }
        public uint ItemId { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }
        public DateTime? ExpectedDate { get; set; }
    }
}