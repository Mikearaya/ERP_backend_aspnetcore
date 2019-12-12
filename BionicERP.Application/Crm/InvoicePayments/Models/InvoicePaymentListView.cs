using System.Linq.Expressions;
/*
 * @CreateTime: Dec 12, 2019 10:58 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 11:03 AM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.InvoicePayments.Models {
    public class InvoicePaymentListView {

        public uint? InvoiceNo { get; set; }
        public float Amount { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public string CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<Invoice, InvoicePaymentListView>> Projection {
            get {
                return payment => new InvoicePaymentListView () {
                    InvoiceNo = payment.Id,
                    Amount = payment.InvoicePayments.Sum (x => x.Amount),
                    PurchaseOrderId = payment.PurchaseOrderId,

                };
            }
        }
    }
}