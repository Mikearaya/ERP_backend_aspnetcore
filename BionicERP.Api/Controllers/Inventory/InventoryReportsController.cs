/*
 * @CreateTime: Dec 18, 2019 8:53 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 18, 2019 8:56 AM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Application.Inventory.Reports.Dashboard;
using BionicERP.Application.Inventory.Reports.Dashboard.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicERP.Api.Controllers.Inventory {
    [Route ("api/inventory/reports")]
    public class InventoryReportsController : Controller {
        private readonly IMediator _Mediator;

        public InventoryReportsController (IMediator mediator) {
            _Mediator = mediator;
        }

        [HttpGet ("dashboard-summary")]
        public async Task<ActionResult<InventoryDashboardSummaryView>> GetInventorySummaryView () {
            var result = await _Mediator.Send (new GetInventoryDashboardViewQuery ());
            return StatusCode (200, result);
        }
    }
}