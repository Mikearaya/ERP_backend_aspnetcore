/*
 * @CreateTime: Dec 11, 2019 2:57 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 2:58 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Crm.Invoices.Commands {
    public class DeleteCustomerInvoiceCommand : IRequest {
        public uint Id { get; set; }
    }
}