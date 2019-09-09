/*
 * @CreateTime: Sep 9, 2019 5:40 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:42 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Roles.Commands {
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UpdateRoleCommandHandler (IBionicERPDatabaseService database,
            RoleManager<ApplicationRole> roleManager) {
            _database = database;
            _roleManager = roleManager;
        }

        public async Task<Unit> Handle (UpdateRoleCommand request, CancellationToken cancellationToken) {
            var role = await _roleManager.Roles
                .FirstOrDefaultAsync (r => r.Id == request.Id);

            if (role == null) {
                throw new NotFoundException ("Role", request.Id);
            }

            role.Name = request.Name;

            var claims = _database.RoleClaims.Where (r => r.RoleId == role.Id).ToList ();

            _database.RoleClaims.RemoveRange (claims);

            foreach (var item in request.Claims) {
                _database.RoleClaims.Add (new RoleClaims () {
                    RoleId = role.Id,
                        ClaimType = item.ClaimType,
                        ClaimValue = item.ClaimValue
                });
            }

            await _roleManager.UpdateAsync (role);
            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}