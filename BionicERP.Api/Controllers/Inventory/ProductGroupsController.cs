/*
 * @CreateTime: Aug 23, 2019 2:33 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:37 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Inventory.ProductGroups;
using BionicERP.Application.Inventory.ProductGroups.Commands;
using BionicERP.Application.Inventory.ProductGroups.Models;
using BionicERP.Application.Inventory.ProductGroups.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Inventory {
    public class ProductGroupsController : Controller {
        private readonly IMediator _Mediator;

        public ProductGroupsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<ProductGroupViewModel>>> GetAllProductGroups ([FromBody] GetProductGroupListQuery query) {

            var ProductGroupList = await _Mediator.Send (query);

            return StatusCode (200, ProductGroupList);
        }

        // api/procurments/ProductGroups/2
        [HttpGet ("{id}")]
        public async Task<ActionResult<ProductGroupViewModel>> FindProductGroupById (uint id) {

            var ProductGroup = await _Mediator.Send (new GetProductGroupByIdQuery () { Id = id });
            return StatusCode (200, ProductGroup);
        }

        // api/procurments/ProductGroups/index
        [HttpGet ("index")]
        public async Task<ActionResult<ProductGroupViewModel>> GetProductGroupsIndex ([FromQuery] GetProductGroupIndexQuery query) {

            var ProductGroup = await _Mediator.Send (query);
            return StatusCode (200, ProductGroup);
        }

        // api/procurments/ProductGroups
        [HttpPost]
        public async Task<ActionResult<ProductGroupViewModel>> CreateProductGroup ([FromBody] CreateProductGroupCommand newProductGroup) {

            var result = await _Mediator.Send (newProductGroup);

            var newProductGroupViewModel = await _Mediator.Send (new GetProductGroupByIdQuery () { Id = result });

            return StatusCode (201, newProductGroupViewModel);

        }

        // api/procurments/ProductGroups/2
        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateProductGroup (uint id, [FromBody] UpdateProductGroupCommand updatedProductGroup) {

            var result = await _Mediator.Send (updatedProductGroup);

            return StatusCode (204);

        }

        // api/procurments/ProductGroups/2
        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteProductGroup (uint id) {

            var result = await _Mediator.Send (new DeleteProductGroupCommand () { Id = id });

            return StatusCode (204);

        }

    }
}