/*
 * @CreateTime: Aug 24, 2019 10:34 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 10:42 AM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Inventory.UnitOfMeasurments.Commands;
using BionicERP.Application.Inventory.UnitOfMeasurments.Models;
using BionicERP.Application.Inventory.UnitOfMeasurments.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Inventory {
    [Route ("api/inventory/unit-of-measurments")]
    public class UnitOfMeasurmentsController : Controller {
        private readonly IMediator _Mediator;

        public UnitOfMeasurmentsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<UnitOfMeasurmentViewModel>>> GetAllUnitOfMeasurments ([FromBody] GetUnitOfMeasurmentsListQuery query) {

            var UnitOfMeasurmentList = await _Mediator.Send (query);

            return StatusCode (200, UnitOfMeasurmentList);
        }

        // api/procurments/UnitOfMeasurments/2
        [HttpGet ("{id}")]
        public async Task<ActionResult<UnitOfMeasurmentViewModel>> FindUnitOfMeasurmentById (uint id) {

            var UnitOfMeasurment = await _Mediator.Send (new GetUnitOfMeasurmentByIdQuery () { Id = id });
            return StatusCode (200, UnitOfMeasurment);
        }

        // api/procurments/UnitOfMeasurments/index
        [HttpGet ("index")]
        public async Task<ActionResult<UnitOfMeasurmentIndexModel>> GetUnitOfMeasurmentsIndex ([FromQuery] GetUnitOfMeasurmentIndexQuery query) {

            var UnitOfMeasurment = await _Mediator.Send (query);
            return StatusCode (200, UnitOfMeasurment);
        }

        // api/procurments/UnitOfMeasurments
        [HttpPost]
        public async Task<ActionResult<UnitOfMeasurmentViewModel>> CreateUnitOfMeasurment ([FromBody] CreateUnitOfMeasurmentCommand newUnitOfMeasurment) {

            var result = await _Mediator.Send (newUnitOfMeasurment);

            var newUnitOfMeasurmentViewModel = await _Mediator.Send (new GetUnitOfMeasurmentByIdQuery () { Id = result });

            return StatusCode (201, newUnitOfMeasurmentViewModel);

        }

        // api/procurments/UnitOfMeasurments/2
        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateUnitOfMeasurment (uint id, [FromBody] UpdateUnitOfMeasurmentCommand updatedUnitOfMeasurment) {

            var result = await _Mediator.Send (updatedUnitOfMeasurment);

            return StatusCode (204);

        }

        // api/procurments/UnitOfMeasurments/2
        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteUnitOfMeasurment (uint id) {

            var result = await _Mediator.Send (new DeleteUnitOfMeasurmentCommand () { Id = id });

            return StatusCode (204);

        }

    }
}