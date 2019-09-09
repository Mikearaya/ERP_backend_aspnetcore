/*
 * @CreateTime: Sep 9, 2019 5:55 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:56 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Roles.Models;
using MediatR;

namespace BionicERP.Application.Roles.Queries {
    public class GetRoleByIdQuery : IRequest<RoleViewModel> {
        public string Id { get; set; }
    }
}