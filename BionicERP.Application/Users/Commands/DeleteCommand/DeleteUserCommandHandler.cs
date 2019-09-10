/*
 * @CreateTime: Sep 10, 2019 9:05 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:07 AM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Users.Commands {
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit> {
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteUserCommandHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<Unit> Handle (DeleteUserCommand request, CancellationToken cancellationToken) {
            ApplicationUser user = await _userManager
                .Users
                .FirstOrDefaultAsync (u => u.Id == request.Id);

            if (user == null) {
                throw new NotFoundException ("User", request.Id);
            }

            await _userManager.DeleteAsync (user);

            return Unit.Value;
        }
    }
}