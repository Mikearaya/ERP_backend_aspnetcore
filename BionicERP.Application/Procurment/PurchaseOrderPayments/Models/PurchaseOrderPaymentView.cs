using System.Linq.Expressions;
/*
 * @CreateTime: Aug 15, 2019 7:45 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 7:52 PM
 * @Description: Modify Here, Please  
 */
using System;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Models {
    public class PurchaseOrderPaymentView {

        public uint Id { get; set; }
        public decimal? Amount { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public string Vendor { get; set; }
        public string CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? PrintCount { get; set; }

        public static Expression<Func<InvoicePayments, PurchaseOrderPaymentView>> Projection {
            get {
                return payment => new PurchaseOrderPaymentView () {
                    Id = payment.Id,
                    Amount = (decimal?) payment.Amount,
                    PurchaseOrderId = payment.PurchaseOrderId,
                    Vendor = payment.PurchaseOrder.Vendor.Name,
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