/*
 * @CreateTime: Nov 6, 2018 8:46 PM
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
    public class InvoicePayments {
        public uint Id { get; set; }
        public uint InvoiceNo { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint CashierId { get; set; }
        public int? PrintCount { get; set; }

        public Employee Cashier { get; set; }
        public Invoice InvoiceNoNavigation { get; set; }
    }
}