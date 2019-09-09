/*
 * @CreateTime: Sep 9, 2019 5:43 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:46 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Roles.Commands {
    public class DeleteRoleCommand : IRequest {
        public string Id { get; set; }
    }
}