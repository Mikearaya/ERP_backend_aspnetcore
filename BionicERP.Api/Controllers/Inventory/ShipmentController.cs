/*
 * @CreateTime: Sep 7, 2019 4:12 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 4:14 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Inventory.Shipments.Commands;
using BionicERP.Application.Inventory.Shipments.Models;
using BionicERP.Application.Inventory.Shipments.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Inventory {
    [Route ("api/inventory/shipments")]
    public class ShipmentController : Controller {
        private readonly IMediator _Mediator;

        public ShipmentController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<ShipmentDetailViewModel>> FindShipmentById (uint id) {
            var Shipment = await _Mediator.Send (new GetShipmentByIdQuery () { Id = id });
            return StatusCode (200, Shipment);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<ShipmentListViewModel>>> GetAllShipments ([FromBody] GetShipmentListQuery query) {

            var Shipments = await _Mediator.Send (query);

            return StatusCode (200, Shipments);

        }

        [HttpPost]
        public async Task<ActionResult<ShipmentDetailViewModel>> CreateShipment ([FromBody] CreateShipmentCommand newShipment) {

            var result = await _Mediator.Send (newShipment);
            var Shipment = await _Mediator.Send (new GetShipmentByIdQuery () { Id = result });

            return StatusCode (201, Shipment);

        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateShipment (uint id, [FromBody] UpdateShipmentCommand updatedShipment) {

            await _Mediator.Send (updatedShipment);

            return StatusCode (204);

        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteShipmentById (uint id) {

            var Shipment = await _Mediator.Send (new DeleteShipmentCommand () { Id = id });

            return StatusCode (204);

        }
    }
}