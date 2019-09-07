/*
 * @CreateTime: Sep 7, 2019 1:39 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:45 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Inventory.WriteOffs.Commands;
using BionicERP.Application.Inventory.WriteOffs.Models;
using BionicERP.Application.Inventory.WriteOffs.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Inventory {

    [Route ("api/inventory/write-offs")]
    public class WriteOffsController : Controller {
        private readonly IMediator _Mediator;

        public WriteOffsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<WriteOffDetailViewModel>> FindWriteOffById (uint id) {
            var writeOff = await _Mediator.Send (new GetWriteOffByIdQuery () { Id = id });
            return StatusCode (200, writeOff);
        }

        // api/inventory/stock-lots
        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<WriteOffViewModel>>> GetAllWriteOffs ([FromBody] GetWriteOffListQuery query) {

            var WriteOffs = await _Mediator.Send (query);

            return StatusCode (200, WriteOffs);

        }

        [HttpPost]
        public async Task<ActionResult<WriteOffDetailViewModel>> CreateWriteOff ([FromBody] CreateWriteOffCommand newwriteOff) {

            var result = await _Mediator.Send (newwriteOff);
            var writeOff = await _Mediator.Send (new GetWriteOffByIdQuery () { Id = result });

            return StatusCode (201, writeOff);

        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateWriteOff (uint id, [FromBody] UpdateWriteOffCommand updatedwriteOff) {

            await _Mediator.Send (updatedwriteOff);

            return StatusCode (204);

        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteWriteOffById (uint id) {

            var writeOff = await _Mediator.Send (new DeleteWriteOffCommand () { Id = id });

            return StatusCode (204);

        }
    }
}