/*
 * @CreateTime: Dec 12, 2019 1:48 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 1:53 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Crm.InvoicePayment.Models;
using MediatR;

namespace BionicERP.Application.Crm.InvoicePayment.Queries {
    public class GetCustomerInvoicePaymentById : IRequest<InvoicePaymentListView> {
        public uint Id { get; set; }
    }
}