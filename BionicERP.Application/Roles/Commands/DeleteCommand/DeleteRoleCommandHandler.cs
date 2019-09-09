/*
 * @CreateTime: Sep 9, 2019 5:44 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:46 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Roles.Commands {
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Unit> {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DeleteRoleCommandHandler (RoleManager<ApplicationRole> roleManager) {
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle (DeleteRoleCommand request, CancellationToken cancellationToken) {
            var role = await _roleManager.Roles
                .FirstOrDefaultAsync (r => r.Id == request.Id);

            if (role == null) {
                throw new NotFoundException ("Role", request.Id);
            }

            await _roleManager.DeleteAsync (role);

            return Unit.Value;
        }
    }
}