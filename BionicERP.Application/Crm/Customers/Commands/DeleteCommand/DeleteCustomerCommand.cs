/*
 * @CreateTime: Sep 7, 2019 5:08 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 7, 2019 5:08 PM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class DeleteCustomerCommand : IRequest {
        public uint Id { get; set; }
    }
}