/*
 * @CreateTime: Sep 8, 2019 5:13 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:18 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicERP.Application.Crm.CustomerOrders.Commands;
using BionicERP.Application.Crm.CustomerOrders.Models;
using BionicERP.Application.Crm.CustomerOrders.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Crm {
    [Route ("api/crm/customer-orders")]
    public class CustomerOrdersController : Controller {
        private readonly IMediator _Mediator;

        public CustomerOrdersController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<CustomerOrderDetailViewModel>> FindCustomerOrderById (uint id) {
            var CustomerOrder = await _Mediator.Send (new GetCustomerOrderByIdQuery () { Id = id });
            return StatusCode (200, CustomerOrder);
        }

        [HttpGet ("index")]
        public async Task<ActionResult<IEnumerable<CustomerOrderIndex>>> GetCustomerOrderIndex ([FromQuery] GetCustomerOrderIndexQuery query) {
            var CustomerOrder = await _Mediator.Send (query);
            return StatusCode (200, CustomerOrder);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<CustomerOrderListViewModel>>> GetAllCustomerOrders ([FromBody] GetCustomerOrderListQuery query) {

            var CustomerOrders = await _Mediator.Send (query);

            return StatusCode (200, CustomerOrders);

        }

        [HttpPost]
        public async Task<ActionResult<CustomerOrderDetailViewModel>> CreateCustomerOrder ([FromBody] CreateCustomerOrderCommand newCustomerOrder) {

            var result = await _Mediator.Send (newCustomerOrder);
            var CustomerOrder = await _Mediator.Send (new GetCustomerOrderByIdQuery () { Id = result });

            return StatusCode (201, CustomerOrder);

        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateCustomerOrder (uint id, [FromBody] UpdateCustomerOrderCommand updatedCustomerOrder) {

            await _Mediator.Send (updatedCustomerOrder);

            return StatusCode (204);

        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteCustomerOrderById (uint id) {

            var CustomerOrder = await _Mediator.Send (new DeleteCustomerOrderCommand () { Id = id });

            return StatusCode (204);

        }
    }
}