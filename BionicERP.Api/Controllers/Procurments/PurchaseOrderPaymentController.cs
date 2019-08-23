/*
 * @CreateTime: Aug 15, 2019 7:58 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 8:04 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Procurment.PurchaseOrderPayments.Commands;
using BionicERP.Application.Procurment.PurchaseOrderPayments.Models;
using BionicERP.Application.Procurment.PurchaseOrderPayments.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Procurments {
    [Route ("api/procurments/purchase-order-payments")]
    public class PurchaseOrderPaymentController : Controller {
        private readonly IMediator _Mediator;

        public PurchaseOrderPaymentController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<PurchaseOrderPaymentView>>> GetAllPurchaseOrderPayments ([FromBody] GetPurchaseOrderPyamentListQuery query) {

            var purchaseOrdersList = await _Mediator.Send (query);

            return StatusCode (200, purchaseOrdersList);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<PurchaseOrderPaymentView>> FindPurchaseOrderPaymentById (uint id) {
            var purchaseOrder = await _Mediator.Send (new GetPurchaseOrderPaymentByIdQuery () { Id = id });

            return StatusCode (200, purchaseOrder);
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseOrderPaymentView>> CreateNewPurchaseOrderPayment ([FromBody] CreatePurchaseOrderPaymentCommand newPurchaseOrder) {
            var purchaseOrderId = await _Mediator.Send (newPurchaseOrder);

            var purchaseOrderDetail = await _Mediator.Send (new GetPurchaseOrderPaymentByIdQuery () { Id = purchaseOrderId });

            return StatusCode (201, purchaseOrderDetail);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdatePurchaseOrderPayment (uint id, [FromBody] UpdatePurchaseOrderPaymentCommand updatedPurchaseOrder) {

            await _Mediator.Send (updatedPurchaseOrder);

            return StatusCode (204);

        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeletePurchaseOrderPayment (uint id) {

            await _Mediator.Send (new DeletePurchaseOrderPaymentCommand () { Id = id });

            return StatusCode (204);

        }
    }
}