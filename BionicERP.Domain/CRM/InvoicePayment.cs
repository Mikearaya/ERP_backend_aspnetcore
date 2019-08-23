/*
 * @CreateTime: Nov 6, 2018 8:46 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 17, 2019 11:32 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicERP.Domain;
using BionicERP.Domain.Procurment;

namespace BionicERP.Domain.CRM {
    public class InvoicePayments {
        public uint Id { get; set; }
        public uint? InvoiceNo { get; set; }
        public float Amount { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public string CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? PrintCount { get; set; }

        public Invoice InvoiceNoNavigation { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}