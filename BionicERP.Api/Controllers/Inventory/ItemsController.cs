/*
 * @CreateTime: Sep 1, 2018 9:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 6, 2019 5:59 PM
 * @Description: Modify Here, Please 
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using BionicERP.Application.Inventory.Items.Commands;
using BionicERP.Application.Inventory.Items.Models;
using BionicERP.Application.Inventory.Items.Queries;
using BionicERP.Application.Inventory.StockBatchs.Models;
using BionicERP.Application.Inventory.StockBatchs.Queries;
using BionicInventory.Application.Stocks.Items.Models;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Inventory {
    [Route ("api/inventory/items")]

    public class ItemsController : Controller {

        public IMediator _Mediator { get; }

        public ItemsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("index")]
        public async Task<ActionResult<IEnumerable<ItemIndexModel>>> GetItemsIndex ([FromQuery] GetItemIndexQuery query) {

            var itemsList = await _Mediator.Send (query);
            return StatusCode (200, itemsList);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<ItemReportListView>>> GetAllItems ([FromBody] GetItemListReportQuery query) {

            var ItemList = await _Mediator.Send (query);

            return StatusCode (200, ItemList);
        }

        [HttpPost ("critical")]
        public async Task<ActionResult<FilterResultModel<ItemReportListView>>> GetAllCriticalItems ([FromBody] GetCriticalItemsQuery query) {

            var ItemList = await _Mediator.Send (query);

            return StatusCode (200, ItemList);
        }

        // api/procurments/Items/2
        [HttpGet ("{id}")]
        public async Task<ActionResult<ItemViewModel>> FindItemById (uint id) {

            var Item = await _Mediator.Send (new GetItemByIdQuery () { Id = id });
            return StatusCode (200, Item);
        }

        // api/procurments/Items
        [HttpPost]
        public async Task<ActionResult<ItemViewModel>> CreateItem ([FromBody] CreateItemCommand newItem) {

            var result = await _Mediator.Send (newItem);

            var newItemViewModel = await _Mediator.Send (new GetItemByIdQuery () { Id = result });

            return StatusCode (201, newItemViewModel);

        }

        // api/procurments/Items/2
        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateItem (uint id, [FromBody] UpdateItemCommand updatedItem) {

            var result = await _Mediator.Send (updatedItem);

            return StatusCode (204);

        }

        // api/procurments/Items/2
        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteItem (uint id) {

            var result = await _Mediator.Send (new DeleteItemCommand () { Id = id });

            return StatusCode (204);

        }

        [HttpPost ("count")]
        public async Task<ActionResult<IEnumerable<InventoryView>>> GetInventoryCount ([FromBody] GetInventoryViewQuery query) {
            var result = await _Mediator.Send (query);
            return StatusCode (200, result);
        }

    }
}