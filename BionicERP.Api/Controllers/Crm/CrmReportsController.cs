/*
 * @CreateTime: Dec 17, 2019 6:14 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2019 6:24 PM
 * @Description: Modify Here, Please  
 */

using System.Threading.Tasks;
using BionicERP.Application.Crm.Reports.Dashboard;
using BionicERP.Application.Crm.Reports.Dashboard.Models;
using BionicERP.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Crm {

    [Route ("api/crm/reports")]
    public class CrmReportsController : Controller {

        private readonly IMediator _Mediator;

        public CrmReportsController (IMediator mediator) {
            _Mediator = mediator;

        }

        [HttpGet ("dashboard-summary")]
        public async Task<ActionResult<DashboardViewModel>> GetDashboardSummaryView () {
            var result = await _Mediator.Send (new GetCrmDashbordViewQuery ());
            return StatusCode (200, result);
        }

    }
}