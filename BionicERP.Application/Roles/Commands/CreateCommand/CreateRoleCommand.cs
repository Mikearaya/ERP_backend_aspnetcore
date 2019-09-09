/*
 * @CreateTime: Sep 9, 2019 5:29 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:37 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Roles.Models;
using MediatR;

namespace BionicERP.Application.Roles.Commands {
    public class CreateRoleCommand : IRequest<string> {

        public string Name { get; set; }

        public IEnumerable<RoleClaimModel> Claims = new List<RoleClaimModel> ();

    }
}