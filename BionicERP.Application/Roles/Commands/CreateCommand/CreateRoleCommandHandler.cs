/*
 * @CreateTime: Sep 9, 2019 5:31 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:37 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Roles.Models;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BionicERP.Application.Roles.Commands {
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public CreateRoleCommandHandler (IBionicERPDatabaseService database, RoleManager<ApplicationRole> roleManager) {
            _database = database;
            _roleManager = roleManager;
        }

        public async Task<string> Handle (CreateRoleCommand request, CancellationToken cancellationToken) {
            ApplicationRole role = new ApplicationRole () {
                Name = request.Name
            };

            var result = await _roleManager.CreateAsync (role);

            if (result.Succeeded) {
                foreach (var item in request.Claims) {
                    await _database.RoleClaims.AddAsync (new RoleClaims () {
                        RoleId = role.Id,
                            ClaimType = item.ClaimType,
                            ClaimValue = item.ClaimValue
                    });
                }

                await _database.SaveAsync ();
                return role.Id;

            }

            throw new Exception (result.Errors.ToString ());
        }
    }
}