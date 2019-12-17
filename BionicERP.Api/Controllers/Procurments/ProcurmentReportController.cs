/*
 * @CreateTime: Dec 17, 2019 8:13 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2019 8:16 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Procurment.Reports.Dashboard;
using BionicERP.Application.Procurment.Reports.Dashboard.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Procurments {

    [Route ("api/procurments/reports")]
    public class ProcurmentReportController : Controller {
        private readonly IMediator _Mediator;

        public ProcurmentReportController (IMediator mediator) {
            _Mediator = mediator;

        }

        [HttpGet ("dashboard-summary")]
        public async Task<ActionResult<ProcurmentSummaryViewModel>> GetProcurmentSummaryView () {
            var result = await _Mediator.Send (new GetProcurmentSummaryViewQuery ());
            return StatusCode (201, result);
        }
    }
}