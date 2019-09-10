/*
 * @CreateTime: Sep 10, 2019 8:53 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 8:58 AM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BionicERP.Application.Users.Commands {
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string> {
        private readonly IBionicERPDatabaseService _database;
        private readonly UserManager<ApplicationUser> _userManager;
        private IMapper _Mapper;

        public CreateUserCommandHandler (IBionicERPDatabaseService database,
            UserManager<ApplicationUser> userManager) {
            _database = database;
            _userManager = userManager;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateUserCommand, ApplicationUser> ();
            }).CreateMapper ();
        }

        public async Task<string> Handle (CreateUserCommand request, CancellationToken cancellationToken) {
            ApplicationUser userModel = _Mapper.Map<CreateUserCommand, ApplicationUser> (request);

            userModel.PasswordHash = "000000";

            var role = await _database.Roles.FindAsync (request.RoleId);

            if (role == null) {
                throw new NotFoundException ("Role", request.RoleId);
            }

            var result = await _userManager.CreateAsync (userModel, "000000");
            _database.UserRoles.Add (new UserRoles () {
                UserId = userModel.Id,
                    RoleId = role.Id
            });

            await _database.SaveAsync ();

            return userModel.Id;
        }
    }
}