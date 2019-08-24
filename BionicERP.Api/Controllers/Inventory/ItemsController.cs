/*
 * @CreateTime: Sep 1, 2018 9:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 10:40 AM
 * @Description: Modify Here, Please 
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using BionicERP.Application.Inventory.Items.Models;
using BionicERP.Application.Inventory.Items.Queries;
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

    }
}