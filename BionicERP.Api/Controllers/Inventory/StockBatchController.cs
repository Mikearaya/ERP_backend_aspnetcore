/*
 * @CreateTime: Aug 24, 2019 5:20 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 2, 2019 4:44 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Inventory.StockBatchs.Commands;
using BionicERP.Application.Inventory.StockBatchs.Models;
using BionicERP.Application.Inventory.StockBatchs.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Inventory {
    [Route ("api/inventory/stock-batchs")]
    public class StockBatchController : Controller {
        private readonly IMediator _Mediator;

        public StockBatchController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<StockBatchDetailView>> FindStockBatchById (uint id) {
            var batch = await _Mediator.Send (new GetStockBatchByIdQuery () { Id = id });
            return StatusCode (200, batch);
        }

        // api/inventory/stock-lots
        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<StockBatchViewModel>>> GetAllStockBatchs ([FromBody] GetStockBatchListQuery query) {

            var stockBatchs = await _Mediator.Send (query);

            return StatusCode (200, stockBatchs);

        }

        [HttpPost]
        public async Task<ActionResult> CreateStockBatch ([FromBody] CreateStockBatchCommand newBatch) {

            var result = await _Mediator.Send (newBatch);

            return StatusCode (201);

        }

        [HttpPut ("{id}")]

        public async Task<ActionResult> UpdateStockBatch (uint id, [FromBody] UpdateStockBatchCommand updatedBatch) {

            await _Mediator.Send (updatedBatch);

            return StatusCode (204);

        }

        [HttpDelete ("{id}")]

        public async Task<ActionResult> DeleteStockBatchById (uint id) {

            var batch = await _Mediator.Send (new DeleteStockBatchCommand () { Id = id });

            return StatusCode (204);

        }

    }
}