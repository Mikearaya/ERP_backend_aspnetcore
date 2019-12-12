/*
 * @CreateTime: Dec 12, 2019 11:31 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 11:34 AM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Crm.InvoicePayments.Models;
using BionicERP.Application.Crm.InvoicePayments.Queries;
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
    }
}