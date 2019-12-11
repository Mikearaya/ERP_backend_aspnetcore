/*
 * @CreateTime: Dec 11, 2019 1:29 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 4:10 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Crm.Invoices.Commands;
using BionicERP.Application.Crm.Invoices.Models;
using BionicERP.Application.Crm.Invoices.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Crm {

    [Route ("api/crm/customer-invoices")]
    public class CustomerOrderInvoiceController : Controller {
        private readonly IMediator _Mediator;

        public CustomerOrderInvoiceController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<CustomerOrderInvoiceDetail>> FindCustomerById (uint id) {
            var Customer = await _Mediator.Send (new GetCustomerOrderInvoiceById () { Id = id });
            return StatusCode (200, Customer);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<CustomerOrderInvoiceList>>> GetAllCustomerOrderInvoicess ([FromBody] GetCustomerOrderInvoiceListQuery query) {

            var CustomerOrders = await _Mediator.Send (query);

            return StatusCode (200, CustomerOrders);

        }

        [HttpPost]
        public async Task<ActionResult<CustomerOrderInvoiceDetail>> CreateInvoice ([FromBody] CreateCustomerOrderInvoiceCommand newInvoice) {

            var result = await _Mediator.Send (newInvoice);
            var invoice = await _Mediator.Send (new GetCustomerOrderInvoiceById () { Id = result });

            return StatusCode (201, invoice);

        }

        [HttpPut ("{id}")]
        public async Task<ActionResult<CustomerOrderInvoiceDetail>> UpdateCustomerInvoice (uint id, [FromBody] UpdateCustomerInvoiceCommand updatedInvoice) {

            var result = await _Mediator.Send (updatedInvoice);

            return StatusCode (204);

        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteCustomerInvoice (uint id) {
            await _Mediator.Send (new DeleteCustomerInvoiceCommand () { Id = id });
            return StatusCode (204);
        }

    }
}