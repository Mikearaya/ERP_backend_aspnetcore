/*
 * @CreateTime: Dec 11, 2019 1:33 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 3:27 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.Invoices.Models {
    public class CustomerOrderInvoiceItemDetail {

        public uint Id { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public float? Discount { get; set; }
        public uint SalesOrderId { get; set; }
        public uint ItemId { get; set; }
        public string Item { get; set; }
        public uint InvoiceNo { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public float UnitPrice { get; set; }
        public float? Tax { get; set; }

        public static Expression<Func<InvoiceDetail, CustomerOrderInvoiceItemDetail>> Projection {
            get {
                return detail => new CustomerOrderInvoiceItemDetail () {
                    Id = detail.Id,
                    Discount = detail.Discount,
                    SalesOrderId = detail.SalesOrderId,
                    ItemId = detail.CustomerOrderItem.ItemId,
                    Item = detail.CustomerOrderItem.Item.Name,
                    InvoiceNo = detail.InvoiceNo,
                    Quantity = detail.Quantity,
                    Note = detail.Note,
                    UnitPrice = detail.UnitPrice,
                    Tax = detail.Tax,
                    DateAdded = detail.DateAddded,
                    DateUpdated = detail.DateUpdated
                };
            }
        }

    }
}