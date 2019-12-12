using System;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;
/*
 * @CreateTime: Dec 12, 2019 11:23 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 4:40 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Crm.InvoicePayment.Models {
    public class InvoicePaymentStatusView {
        public uint InvoiceId { get; set; }

        public string CustomerName { get; set; }
        public decimal? PaidAmount { get; set; } = 0;
        public decimal TotalAmount { get; set; }
        public decimal? RemainingAmount {
            get {
                return (decimal) TotalAmount - PaidAmount;
            }
        }

        public static Expression<Func<Invoice, InvoicePaymentStatusView>> Projection {

            get {
                return payment => new InvoicePaymentStatusView () {
                    InvoiceId = payment.Id,
                    CustomerName = payment.CustomerOrder.Client.FullName,
                    PaidAmount = (decimal?) payment.InvoicePayments.Sum (i => i.Amount),
                    TotalAmount = (decimal) payment.InvoiceDetail.Sum (i => i.UnitPrice * i.Quantity)

                };
            }

        }
    }
}