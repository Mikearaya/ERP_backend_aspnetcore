/*
 * @CreateTime: Aug 9, 2019 2:15 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 17, 2019 11:21 AM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicERP.Application.Procurment.PurchaseOrders.Commands;
using BionicERP.Application.Procurment.PurchaseOrders.Models;
using BionicERP.Application.Procurment.PurchaseOrders.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Procurments {
    [Route ("api/procurments/purchase-orders")]
    public class PurchaseOrdersController : Controller {
        private readonly IMediator _Mediator;

        public PurchaseOrdersController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<PurchaseOrderView>>> GetAllPurchaseOrders ([FromBody] GetPurchaseOrderListQuery query) {

            var purchaseOrdersList = await _Mediator.Send (query);

            return StatusCode (200, purchaseOrdersList);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<PurchaseOrderDetailView>> FindPurchaseOrderById (uint id) {
            var purchaseOrder = await _Mediator.Send (new GetPurchaseOrderByIdQuery () { Id = id });

            return StatusCode (200, purchaseOrder);
        }

        [HttpGet ("index")]
        public async Task<ActionResult<IEnumerable<PurchaseOrderIndexModel>>> GetPurchaseOrderIndex ([FromQuery] GetPurchaseOrderIndexQuery query) {
            var purchaseOrder = await _Mediator.Send (query);

            return StatusCode (200, purchaseOrder);
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseOrderDetailView>> CreateNewPurchaseOrder ([FromBody] CreatePurchaseOrderCommand newPurchaseOrder) {
            var purchaseOrderId = await _Mediator.Send (newPurchaseOrder);

            var purchaseOrderDetail = await _Mediator.Send (new GetPurchaseOrderByIdQuery () { Id = purchaseOrderId });

            return StatusCode (201, purchaseOrderDetail);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdatePurchaseOrder (uint id, [FromBody] UpdatePurchaseOrderCommand updatedPurchaseOrder) {

            await _Mediator.Send (updatedPurchaseOrder);

            return StatusCode (204);

        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeletePurchaseOrder (uint id) {

            await _Mediator.Send (new DeletePurchaseOrderCommand () { Id = id });

            return StatusCode (204);

        }

    }
}