/*
 * @CreateTime: Dec 11, 2019 1:23 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 1:44 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Crm.Invoices.Models;
using MediatR;

namespace BionicERP.Application.Crm.Invoices.Queries {
    public class GetCustomerOrderInvoiceById : IRequest<CustomerOrderInvoiceDetail> {
        public uint Id { get; set; }
    }
}