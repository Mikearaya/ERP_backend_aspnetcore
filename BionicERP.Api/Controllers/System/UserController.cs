/*
 * @CreateTime: Sep 10, 2019 9:23 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:31 AM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicERP.Application.Users.Commands;
using BionicERP.Application.Users.Models;
using BionicERP.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.System {

    [Route ("api/system-users")]
    public class UserController : Controller {
        private readonly IMediator _Mediator;

        public UserController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<UserViewModel>> FindUserById (string id) {

            var user = await _Mediator.Send (new GetUserByIdQuery () { Id = id });

            return StatusCode (200, user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers () {

            var user = await _Mediator.Send (new GetUserListQuery ());
            return StatusCode (200, user);
        }

        [HttpGet ("index")]
        public async Task<ActionResult<IEnumerable<UserIndexModel>>> GetUsersIndex ([FromQuery] GetUserIndexQuery query) {
            var users = await _Mediator.Send (query);
            return StatusCode (200, users);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers ([FromBody] GetUserListQuery query) {

            var user = await _Mediator.Send (query);
            return StatusCode (200, user);
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> CreateUser ([FromBody] CreateUserCommand newUser) {

            var result = await _Mediator.Send (newUser);

            var user = await _Mediator.Send (new GetUserByIdQuery () { Id = result });
            return StatusCode (201, user);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateUser (string id, [FromBody] UpdateUserCommand updatedUser) {
            var asss = await _Mediator.Send (updatedUser);
            return StatusCode (204);
        }

        [HttpPut ("{id}/password")]
        public async Task<IActionResult> UpdateUserPassword (string id, [FromBody] UpdateUserPasswordCommand updatedUserPassword) {

            var asss = await _Mediator.Send (updatedUserPassword);
            return StatusCode (204);

        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteUser (string id) {

            var user = await _Mediator.Send (new DeleteUserCommand () { Id = id });
            return StatusCode (204);
        }

    }
}