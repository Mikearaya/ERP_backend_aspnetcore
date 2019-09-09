/*
 * @CreateTime: Sep 9, 2019 5:51 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 9, 2019 5:51 PM 
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Roles.Models;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Roles.Queries {
    public class GetRoleIndexQueryHandler : IRequestHandler<GetRoleIndexQuery, IEnumerable<RoleIndexModel>> {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public GetRoleIndexQueryHandler (RoleManager<ApplicationRole> roleManager) {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<RoleIndexModel>> Handle (GetRoleIndexQuery request, CancellationToken cancellationToken) {
            return await _roleManager.Roles
                .Where (r => r.NormalizedName.StartsWith (request.Name.Trim ().ToUpper ()))
                .Select (RoleIndexModel.Projection)
                .ToListAsync ();
        }
    }
}