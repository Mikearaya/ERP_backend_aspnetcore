/*
 * @CreateTime: Jan 27, 2019 7:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 7, 2019 5:58 PM
 * @Description: Modify Here, Please 
 */

using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Models;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BionicERP.Application.Security {
    public class AuthenticationQueryHandler : IRequestHandler<AuthenticationQuery, ApplicationUser> {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationQueryHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }
        public async Task<ApplicationUser> Handle (AuthenticationQuery request, CancellationToken cancellationToken) {
            var user = await _userManager.FindByNameAsync (request.UserName);

            if (user != null && await _userManager.CheckPasswordAsync (user, request.Password)) {
                return user;
            }
            throw new NotFoundException ("Username or password not correct");

        }
    }
}