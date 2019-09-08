/*
 * @CreateTime: Sep 8, 2019 4:54 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:19 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Crm.CustomerOrders.Models;
using MediatR;

namespace BionicERP.Application.Crm.CustomerOrders.Queries {
    public class GetCustomerOrderByIdQuery : IRequest<CustomerOrderDetailViewModel> {
        public uint Id { get; set; }

    }
}