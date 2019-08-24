/*
 * @CreateTime: Aug 24, 2019 11:17 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 11:19 AM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Inventory.StorageLocations.Commands;
using BionicERP.Application.Inventory.StorageLocations.Models;
using BionicERP.Application.Inventory.StorageLocations.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Inventory {
    [Route ("api/inventory/storage-locations")]
    public class StorageLocationsController : Controller {
        private readonly IMediator _Mediator;

        public StorageLocationsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<StorageLocationViewModel>>> GetAllStorageLocations ([FromBody] GetStorageLocationListQuery query) {

            var StorageLocationList = await _Mediator.Send (query);

            return StatusCode (200, StorageLocationList);
        }

        // api/procurments/StorageLocations/2
        [HttpGet ("{id}")]
        public async Task<ActionResult<StorageLocationViewModel>> FindStorageLocationById (uint id) {

            var StorageLocation = await _Mediator.Send (new GetStorageLocationByIdQuery () { Id = id });
            return StatusCode (200, StorageLocation);
        }

        // api/procurments/StorageLocations/index
        [HttpGet ("index")]
        public async Task<ActionResult<StorageLocationIndexModel>> GetStorageLocationsIndex ([FromQuery] GetStorageLocationIndexQuery query) {

            var StorageLocation = await _Mediator.Send (query);
            return StatusCode (200, StorageLocation);
        }

        // api/procurments/StorageLocations
        [HttpPost]
        public async Task<ActionResult<StorageLocationViewModel>> CreateStorageLocation ([FromBody] CreateStorageLocationCommand newStorageLocation) {

            var result = await _Mediator.Send (newStorageLocation);

            var newStorageLocationViewModel = await _Mediator.Send (new GetStorageLocationByIdQuery () { Id = result });

            return StatusCode (201, newStorageLocationViewModel);

        }

        // api/procurments/StorageLocations/2
        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateStorageLocation (uint id, [FromBody] UpdateStorageLocationCommand updatedStorageLocation) {

            var result = await _Mediator.Send (updatedStorageLocation);

            return StatusCode (204);

        }

        // api/procurments/StorageLocations/2
        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteStorageLocation (uint id) {

            var result = await _Mediator.Send (new DeleteStorageLocationCommand () { Id = id });

            return StatusCode (204);

        }
    }
}