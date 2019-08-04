/*
 * @CreateTime: Oct 2, 2018 8:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 8:52 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicERP.Domain;

namespace BionicERP.Domain.CRM {
    public class Invoice {
        public Invoice () {
            InvoiceDetail = new List<InvoiceDetail> ();
            InvoicePayments = new List<InvoicePayments> ();
        }

        public uint Id { get; set; }
        public uint PurchaseOrderId { get; set; }

        public uint PreparedBy { get; set; }
        public byte? PrintCount { get; set; } = 0;
        public string InvoiceType { get; set; }

        public string PaymentMethod { get; set; }
        public float Tax { get; set; }
        public string Note { get; set; }
        public float Discount { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DueDate { get; set; }

        public Employee PreparedByNavigation { get; set; }
        public CustomerOrder CustomerOrder { get; set; }
        public List<InvoiceDetail> InvoiceDetail { get; set; }
        public List<InvoicePayments> InvoicePayments { get; set; }
    }
}