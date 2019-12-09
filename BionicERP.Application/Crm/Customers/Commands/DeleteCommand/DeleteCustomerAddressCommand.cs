/*
 * @CreateTime: Dec 9, 2019 6:23 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2019 6:37 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class DeleteCustomerAddressCommand : IRequest {

        public uint CustomerId { get; set; }
        public uint Id { get; set; }
    }
}