/*
 * @CreateTime: Dec 12, 2019 11:24 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Dec 12, 2019 11:24 AM 
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Crm.InvoicePayments.Models;
using MediatR;

namespace BionicERP.Application.Crm.InvoicePayments.Queries {
    public class GetInvoicePaymentStatusQuery : IRequest<InvoicePaymentStatusView> {
        public uint Id { get; set; }
    }
}