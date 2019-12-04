/*
 * @CreateTime: Sep 9, 2019 6:09 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 6:14 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicERP.Application.Roles.Commands;
using BionicERP.Application.Roles.Models;
using BionicERP.Application.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.System {

    [Route ("api/system-roles")]
    public class RolesController : Controller {
        private readonly IMediator _Mediator;

        public RolesController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType (200)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<RoleViewModel>>> GetAllUserRoles () {
            var roles = await _Mediator.Send (new GetRoleListQuery ());
            return StatusCode (200, roles);

        }

        [HttpGet ("index")]
        public async Task<ActionResult<IEnumerable<RoleViewModel>>> GetRolesIndex ([FromQuery] GetRoleIndexQuery query) {
            var roles = await _Mediator.Send (query);
            return StatusCode (200, roles);

        }

        [HttpPost ("filter")]
        public async Task<ActionResult<IEnumerable<RoleViewModel>>> GetAllUserRoles ([FromBody] GetRoleListQuery query) {
            var roles = await _Mediator.Send (query);
            return StatusCode (200, roles);

        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<RoleViewModel>> GetRoleById (string id) {
            var role = await _Mediator.Send (new GetRoleByIdQuery () { Id = id });
            return StatusCode (200, role);

        }

        [HttpPost]
        public async Task<ActionResult<RoleViewModel>> Create ([FromBody] CreateRoleCommand newRole) {

            if (newRole == null) {
                return StatusCode (400);
            }
            if (!ModelState.IsValid) {
                return StatusCode (422);
            }

            var result = await _Mediator.Send (newRole);

            var role = await _Mediator.Send (new GetRoleByIdQuery () { Id = result });

            return StatusCode (201, role);
        }

        [HttpPut ("{id}")]

        public async Task<ActionResult> UpdateRole ([FromBody] UpdateRoleCommand updatedRole) {

            if (updatedRole == null) {
                return StatusCode (400);
            }
            if (!ModelState.IsValid) {
                return StatusCode (422);
            }

            var result = await _Mediator.Send (updatedRole);

            return StatusCode (204);
        }

        [HttpDelete ("{id}")]

        public async Task<ActionResult> DeleteRole (string id) {

            var result = await _Mediator.Send (new DeleteRoleCommand () { Id = id });
            return StatusCode (204);
        }
    }
}