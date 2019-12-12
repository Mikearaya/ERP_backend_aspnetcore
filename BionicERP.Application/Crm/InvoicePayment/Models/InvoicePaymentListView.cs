/*
 * @CreateTime: Dec 12, 2019 11:51 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 4:03 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.InvoicePayment.Models {
    public class InvoicePaymentListView {

        public uint Id { get; set; }
        public uint? InvoiceNo { get; set; }
        public string CustomerName { get; set; }
        public float Amount { get; set; }

        public string CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public static Expression<Func<InvoicePayments, InvoicePaymentListView>> Projection {
            get {
                return payment => new InvoicePaymentListView () {
                    Id = payment.Id,
                    InvoiceNo = payment.InvoiceNo,
                    Amount = payment.Amount,
                    CustomerName = payment.InvoiceNoNavigation.CustomerOrder.Client.FullName,
                    CheckNo = payment.CheckNo,
                    Date = payment.Date,
                    Note = payment.Note,
                    DateAdded = payment.DateAdded,
                    DateUpdated = payment.DateUpdated
                };
            }
        }

    }
}