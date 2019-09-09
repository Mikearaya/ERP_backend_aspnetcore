/*
 * @CreateTime: Sep 9, 2019 5:49 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:50 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Roles.Models;
using MediatR;

namespace BionicERP.Application.Roles.Queries {
    public class GetRoleIndexQuery : IRequest<IEnumerable<RoleIndexModel>> {
        private string filter { get; set; } = "";
        public string Name {
            get {
                return filter;
            }
            set {
                filter = (value == null) ? "" : value;
            }
        }
    }
}