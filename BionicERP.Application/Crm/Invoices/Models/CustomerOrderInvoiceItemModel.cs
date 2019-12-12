/*
 * @CreateTime: Dec 11, 2019 1:53 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 2:10 PM
 * @Description: Modify Here, Please  
 */
using System;

namespace BionicERP.Application.Crm.Invoices.Models {
    public class CustomerOrderInvoiceItemModel {

        public uint Id { get; set; }

        public float? Discount { get; set; }
        public uint SalesOrderId { get; set; }
        public uint InvoiceNo { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public float UnitPrice { get; set; }
        public float? Tax { get; set; }

    }
}