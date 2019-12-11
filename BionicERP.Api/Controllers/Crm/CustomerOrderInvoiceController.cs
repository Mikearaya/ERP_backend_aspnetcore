/*
 * @CreateTime: Dec 11, 2019 1:29 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 1:48 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Crm.Invoices.Models;
using BionicERP.Application.Crm.Invoices.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Crm {

    [Route ("crm/customer-invoices")]
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
    }
}