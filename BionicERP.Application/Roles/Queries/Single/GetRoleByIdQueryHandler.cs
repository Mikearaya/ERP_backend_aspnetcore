/*
 * @CreateTime: Sep 9, 2019 5:56 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:59 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Roles.Models;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Roles.Queries {
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleViewModel> {

        private readonly RoleManager<ApplicationRole> _roleManager;

        public GetRoleByIdQueryHandler (RoleManager<ApplicationRole> roleManager) {

            _roleManager = roleManager;
        }

        public async Task<RoleViewModel> Handle (GetRoleByIdQuery request, CancellationToken cancellationToken) {
            var role = await _roleManager.Roles
                .Where (r => r.Id == request.Id)
                .Select (RoleViewModel.Projection)
                .FirstOrDefaultAsync ();

            if (role == null) {
                throw new NotFoundException ("Role", request.Id);
            }

            return role;
        }
    }
}