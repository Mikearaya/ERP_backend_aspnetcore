/*
 * @CreateTime: Sep 9, 2019 5:37 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:42 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Roles.Models;
using MediatR;

namespace BionicERP.Application.Roles.Commands {
    public class UpdateRoleCommand : IRequest {
        public string Id { get; set; }
        public string Name { get; set; }

        public IList<RoleClaimModel> Claims { get; set; } = new List<RoleClaimModel> ();
    }
}