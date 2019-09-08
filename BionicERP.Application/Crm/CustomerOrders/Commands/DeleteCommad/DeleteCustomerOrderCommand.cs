/*
 * @CreateTime: Sep 8, 2019 4:46 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 4:47 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Crm.CustomerOrders.Commands {
    public class DeleteCustomerOrderCommand : IRequest {
        public uint Id { get; set; }
    }
}