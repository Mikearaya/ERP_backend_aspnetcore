/*
 * @CreateTime: Sep 10, 2019 9:25 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:28 AM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Users.Models;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Users.Queries {
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel> {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserByIdQueryHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<UserViewModel> Handle (GetUserByIdQuery request, CancellationToken cancellationToken) {
            UserViewModel user = await _userManager.Users
                .Select (UserViewModel.Projection)
                .FirstOrDefaultAsync (u => u.Id == request.Id);

            return user;
        }
    }
}