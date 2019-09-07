/*
 * @CreateTime: Sep 7, 2019 5:36 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 7, 2019 5:36 PM 
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Crm.Customers.Models;
using MediatR;

namespace BionicERP.Application.Crm.Customers.Queries {
    public class GetCustomerByIdQuery : IRequest<CustomerDetailViewModel> {
        public uint Id { get; set; }
    }
}