using System;
using System.Collections.Generic;
using BionicERP.Application.Crm.Invoices.Models;
/*
 * @CreateTime: Dec 11, 2019 1:54 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 2:07 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Crm.Invoices.Commands {
    public class CreateCustomerOrderInvoiceCommand : IRequest<uint> {
        public CreateCustomerOrderInvoiceCommand () {
            InvoiceDetail = new List<CustomerOrderInvoiceItemModel> ();
        }

        public uint PurchaseOrderId { get; set; }

        public uint PreparedBy { get; set; }
        public string InvoiceType { get; set; }
        public DateTime DueDate { get; set; }

        public string PaymentMethod { get; set; }
        public float Tax { get; set; }
        public string Note { get; set; }
        public float Discount { get; set; }
        public IEnumerable<CustomerOrderInvoiceItemModel> InvoiceDetail { get; set; }

    }
}