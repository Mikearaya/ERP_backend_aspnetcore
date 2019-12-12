/*
 * @CreateTime: Dec 12, 2019 2:10 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Dec 12, 2019 2:10 PM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Crm.InvoicePayment.Commands {
    public class DeleteCustomerInvoicePaymentCommand : IRequest {
        public uint Id { get; set; }
    }
}