/*
 * @CreateTime: Dec 24, 2018 8:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 10, 2019 4:00 PM
 * @Description: Modify Here, Please 
 */

using System.Threading.Tasks;
using BionicERP.Application.Procurment.Vendors.Commands;
using BionicERP.Application.Procurment.Vendors.Queries;
using BionicInventory.Application.Procurment.Vendors.Models;
using BionicInventory.Application.Procurment.Vendors.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Procurments.Vendors {

    [Route ("api/procurments/vendors")]
    public class VendorsController : Controller {
        private readonly IMediator _Mediator;

        public VendorsController (IMediator mediator) {
            _Mediator = mediator;
        }

        // api/procurments/vendors/filter
        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<VendorView>>> GetAllVendors ([FromBody] GetVendorsListQuery query) {

            var vendorList = await _Mediator.Send (query);

            return StatusCode (200, vendorList);
        }

        // api/procurments/vendors/2
        [HttpGet ("{id}")]
        public async Task<ActionResult<VendorView>> FindVendorById (uint id) {

            var vendor = await _Mediator.Send (new GetVendorByIdQuery () { Id = id });
            return StatusCode (200, vendor);
        }

        // api/procurments/vendors/2
        [HttpGet ("{id}/purchase-terms")]
        public async Task<ActionResult<VendorView>> GetVendorPurchaseTerm (uint id) {

            var vendor = await _Mediator.Send (new GetVendorPurchaseTermQuery () { VendorId = id });
            return StatusCode (200, vendor);
        }

        // api/procurments/vendors/index
        [HttpGet ("index")]
        public async Task<ActionResult<VendorView>> GetVendorsIndex ([FromQuery] GetVendorIndexQuery query) {

            var vendor = await _Mediator.Send (query);
            return StatusCode (200, vendor);
        }

        // api/procurments/vendors
        [HttpPost]
        public async Task<ActionResult<VendorView>> CreateVendor ([FromBody] CreateVendorCommand newVendor) {

            var result = await _Mediator.Send (newVendor);

            var newVendorView = await _Mediator.Send (new GetVendorByIdQuery () { Id = result });

            return StatusCode (201, newVendorView);

        }

        // api/procurments/vendors/2
        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateVendor (uint id, [FromBody] UpdateVendorCommand updatedVendor) {

            var result = await _Mediator.Send (updatedVendor);

            return StatusCode (204);

        }

        // api/procurments/vendors/2
        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteVendor (uint id) {

            var result = await _Mediator.Send (new DeleteVendorCommand () { Id = id });

            return StatusCode (204);

        }

    }
}