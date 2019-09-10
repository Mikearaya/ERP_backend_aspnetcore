/*
 * @CreateTime: Sep 10, 2019 9:11 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:12 AM
 * @Description: Modify Here, Please  
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BionicERP.Application.Users.Commands {
    public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand, Unit> {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateUserPasswordCommandHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<Unit> Handle (UpdateUserPasswordCommand request, CancellationToken cancellationToken) {
            ApplicationUser user = await _userManager.FindByIdAsync (request.Id);

            if (user == null) {
                throw new NotFoundException ("User", request.Id);
            }

            var result = await _userManager.ChangePasswordAsync (user, request.CurrentPassword, request.NewPassword);

            if (!result.Succeeded) {
                throw new Exception (result.Errors.ToString ());
            }
            return Unit.Value;
        }
    }
}