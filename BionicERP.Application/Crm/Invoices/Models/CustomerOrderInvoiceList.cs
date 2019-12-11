/*
 * @CreateTime: Dec 11, 2019 1:12 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 1:20 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.Invoices.Models {
    public class CustomerOrderInvoiceList {

        public uint Id { get; set; }
        public string CustomerName { get; set; }
        public uint PurchaseOrderId { get; set; }
        public uint PreparedBy { get; set; }
        public byte? PrintCount { get; set; } = 0;
        public string InvoiceType { get; set; }
        public string PaymentMethod { get; set; }
        public float Tax { get; set; }
        public string Note { get; set; }
        public float Discount { get; set; }
        public string Status { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DueDate { get; set; }

        public static Expression<Func<Invoice, CustomerOrderInvoiceList>> Projection {
            get {
                return invoice => new CustomerOrderInvoiceList () {
                    Id = invoice.Id,
                    PurchaseOrderId = invoice.PurchaseOrderId,
                    InvoiceType = invoice.InvoiceType,
                    PaymentMethod = invoice.PaymentMethod,
                    Tax = invoice.Tax,
                    Discount = invoice.Discount,
                    DateAdded = invoice.DateAdded,
                    DateUpdated = invoice.DateUpdated,
                    DueDate = invoice.DueDate,
                    CustomerName = invoice.CustomerOrder.Client.FullName

                };
            }
        }

    }
}