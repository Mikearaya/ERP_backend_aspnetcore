/*
 * @CreateTime: Sep 10, 2019 9:00 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:03 AM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Users.Commands {
    public class UpdateUserCommadHandler : IRequestHandler<UpdateUserCommand, Unit> {
        private readonly UserManager<ApplicationUser> _userManager;
        private IMapper _Mapper;
        public UpdateUserCommadHandler (UserManager<ApplicationUser> userManager) {

            _userManager = userManager;

            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateUserCommand, ApplicationUser> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateUserCommand request, CancellationToken cancellationToken) {
            ApplicationUser user = await _userManager.Users
                .FirstOrDefaultAsync (u => u.Id == request.Id);

            if (user == null) {
                throw new NotFoundException ("User", request.Id);
            }

            _Mapper.Map (request, user);

            await _userManager.UpdateAsync (user);

            return Unit.Value;
        }
    }
}