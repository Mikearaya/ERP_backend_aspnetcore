/*
 * @CreateTime: Dec 11, 2019 2:46 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 2:47 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Crm.Invoices.Models;
using MediatR;

namespace BionicERP.Application.Crm.Invoices.Commands {
    public class UpdateCustomerInvoiceCommand : IRequest {
        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }
        public uint PreparedBy { get; set; }
        public string InvoiceType { get; set; }
        public string PaymentMethod { get; set; }
        public float Tax { get; set; }
        public string Note { get; set; }
        public float Discount { get; set; }
        public IEnumerable<CustomerOrderInvoiceItemModel> InvoiceDetail { get; set; }

    }
}