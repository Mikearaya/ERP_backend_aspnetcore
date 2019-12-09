using System.Collections.Generic;
/*
 * @CreateTime: Sep 7, 2019 5:49 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2019 6:58 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Crm.Customers.Commands;
using BionicERP.Application.Crm.Customers.Models;
using BionicERP.Application.Crm.Customers.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Crm {

    [Route ("api/crm/customers")]
    public class CustomersController : Controller {
        private readonly IMediator _Mediator;

        public CustomersController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<CustomerDetailViewModel>> FindCustomerById (uint id) {
            var Customer = await _Mediator.Send (new GetCustomerByIdQuery () { Id = id });
            return StatusCode (200, Customer);
        }

        [HttpGet ("index")]
        public async Task<ActionResult<IEnumerable<CustomerIndexModel>>> GetCustomerIndex ([FromQuery] GetCustomerIndexQuery query) {
            var Customer = await _Mediator.Send (query);
            return StatusCode (200, Customer);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<CustomerListViewModel>>> GetAllCustomers ([FromBody] GetCustomerListQuery query) {

            var Customers = await _Mediator.Send (query);

            return StatusCode (200, Customers);

        }

        [HttpPost]
        public async Task<ActionResult<CustomerDetailViewModel>> CreateCustomer ([FromBody] CreateCustomerCommand newCustomer) {

            var result = await _Mediator.Send (newCustomer);
            var Customer = await _Mediator.Send (new GetCustomerByIdQuery () { Id = result });

            return StatusCode (201, Customer);

        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateCustomer (uint id, [FromBody] UpdateCustomerCommand updatedCustomer) {

            await _Mediator.Send (updatedCustomer);

            return StatusCode (204);

        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteCustomerById (uint id) {

            var Customer = await _Mediator.Send (new DeleteCustomerCommand () { Id = id });

            return StatusCode (204);

        }

        [HttpDelete ("{customerId}/address/{id}")]
        public async Task<ActionResult> DeleteCustomerAddress (uint customerId, uint id) {
            await _Mediator.Send (new DeleteCustomerAddressCommand () { Id = id, CustomerId = customerId });
            return StatusCode (204);
        }

        [HttpDelete ("{customerId}/social-media/{id}")]
        public async Task<ActionResult> DeleteCustomerSocialAddress (uint customerId, uint id) {
            await _Mediator.Send (new DeleteCustomerSocialMediaCommand () { CustomerId = customerId, Id = id });
            return StatusCode (204);
        }
    }
}