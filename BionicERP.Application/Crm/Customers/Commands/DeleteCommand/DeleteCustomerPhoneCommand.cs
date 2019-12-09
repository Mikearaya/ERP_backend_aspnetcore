/*
 * @CreateTime: Dec 9, 2019 7:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Dec 9, 2019 7:02 PM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class DeleteCustomerPhoneCommand : IRequest {

        public uint Id { get; set; }
        public uint CustomerId { get; set; }
    }
}