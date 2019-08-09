/*
 * @CreateTime: Dec 24, 2018 10:09 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 10:10 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicERP.Application.Procurment.PurchaseTerms.Commands;
using BionicERP.Application.Procurment.PurchaseTerms.Models;
using BionicERP.Application.Procurment.PurchaseTerms.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Procurments.Vendors.PurchaseTerms {

    [Route ("api/procurments/purchase-terms")]
    public class VendorPurchaseTermController : Controller {
        private readonly IMediator _Mediator;

        public VendorPurchaseTermController (IMediator mediator) {
            _Mediator = mediator;
        }

        // api/procurments/purchaseterms/2
        [HttpGet ("{id}")]
        public async Task<ActionResult<PurchaseTermViewModel>> GetPurchaseTermById (uint id) {

            var term = await _Mediator.Send (new GetPurchaseTermByIdQuery () { Id = id });

            return StatusCode (200, term);

        }

        // api/procurments/vendors/2/purchaseterms
        [HttpPost ("filter")]
        public async Task<ActionResult<IEnumerable<PurchaseTermViewModel>>> GetVendorPurchaseTerms ([FromBody] GetPurchaseTermsListQuery query) {

            var vendorPurchaseTerms = await _Mediator.Send (query);
            return StatusCode (200, vendorPurchaseTerms);

        }

        // api/procurments/purchaseterms
        [HttpPost]

        public async Task<ActionResult<PurchaseTermViewModel>> CreatePurchaseTerm ([FromBody] CreatePurchaseTermCommand newPurchaseTerm) {

            var result = await _Mediator.Send (newPurchaseTerm);

            var newTerm = await _Mediator.Send (new GetPurchaseTermByIdQuery () { Id = result });

            return StatusCode (201, newTerm);

        }

        // api/procurments/purchaseterms/2
        [HttpPut ("{id}")]
        public async Task<ActionResult> updatePurchaseTerm (uint id, [FromBody] UpdatePurchaseTermCommand updatedPurchaseTerm) {

            var result = await _Mediator.Send (updatedPurchaseTerm);

            return StatusCode (204);

        }

        // api/procurments/purchaseterms/2
        [HttpDelete ("{id}")]
        public async Task<ActionResult> deletePurchaseTerm (uint id) {

            var result = await _Mediator.Send (new DeletePurchaseTermCommand () { Id = id });

            return StatusCode (204);

        }
    }
}