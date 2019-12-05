/*
 * @CreateTime: Aug 9, 2019 2:20 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 2:21 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrders.Commands {
    public class UpdatePurchaseOrderCommand : IRequest {

        public UpdatePurchaseOrderCommand () {
            PurchaseOrderItems = new List<PurchaseOrderItem> ();
        }

        public uint Id { get; set; }
        public uint VendorId { get; set; }
        public string Status { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime? OrderedDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public float? Tax { get; set; }
        public float? AdditionalFee { get; set; } = 0;
        public float? Discount { get; set; }
        public string OrderId { get; set; }
        public DateTime? ArivalDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }

        public IEnumerable<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }

}