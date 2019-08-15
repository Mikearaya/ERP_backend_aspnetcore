/*
 * @CreateTime: Aug 9, 2019 8:39 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 2:32 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Procurment.PurchaseOrders.Models;
using BionicERP.Application.Procurment.PurchaseOrders.Queries;
using BionicERP.Application.Procurment.PurchaseRecievings.Commands;
using BionicERP.Application.Procurment.PurchaseRecievings.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Procurments {

    [Route ("api/procurments/purchase-recievings")]
    public class PurchaseRecievingsController : Controller {
        private readonly IMediator _Mediator;

        public PurchaseRecievingsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<PurchaseOrderView>>> GetShippedPurchaseOrders ([FromBody] GetShippedPurchaseOrdersListQuery query) {
            var shippedOrders = await _Mediator.Send (query);
            return Ok (shippedOrders);
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseOrderDetailView>> AddNewPurchaseRecieving ([FromBody] CreatePurchaseRecievingCommand newPurchaseRecieving) {

            var purchaseOrderId = await _Mediator.Send (newPurchaseRecieving);

            var purchaseOrderDetail = await _Mediator.Send (new GetPurchaseOrderByIdQuery () { Id = purchaseOrderId });

            return StatusCode (201, purchaseOrderDetail);

        }

    }
}