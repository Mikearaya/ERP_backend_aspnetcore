/*
 * @CreateTime: Dec 12, 2019 11:31 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 2:08 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Crm.InvoicePayment.Commands;
using BionicERP.Application.Crm.InvoicePayment.Models;
using BionicERP.Application.Crm.InvoicePayment.Queries;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Crm {

    [Route ("api/invoice-payments")]
    public class InvoicePaymentController : Controller {
        private readonly IMediator _Mediator;

        public InvoicePaymentController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("{id}/remaining")]
        public async Task<ActionResult<InvoicePaymentStatusView>> GetInvoicePaymentStatus (uint id) {
            var payment = await _Mediator.Send (new GetInvoicePaymentStatusQuery () { Id = id });
            return StatusCode (200, payment);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<InvoicePaymentListView>> GetCustomerInvoicePaymentById (uint id) {
            var result = await _Mediator.Send (new GetCustomerInvoicePaymentById () { Id = id });
            return StatusCode (200, result);
        }

        [HttpPost]
        public async Task<ActionResult<InvoicePaymentListView>> CreateInvoicePayment ([FromBody] CreateCustomerInvoicePaymentCommand command) {
            var result = await _Mediator.Send (command);
            return StatusCode (201);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> UpdateCustomerInvoicePayment (uint id, [FromBody] UpdateCustomerInvoiceCommand command) {
            var result = await _Mediator.Send (command);
            return StatusCode (204);
        }

        [HttpPost ("filter")]
        public async Task<ActionResult<FilterResultModel<InvoicePaymentListView>>> GetInvoicePaymentsList ([FromBody] GetInvoicePaymentListQuery query) {
            var result = await _Mediator.Send (query);
            return StatusCode (200, result);

        }
    }
}