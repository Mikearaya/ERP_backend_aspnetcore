/*
 * @CreateTime: Dec 17, 2019 3:58 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2019 4:14 PM
 * @Description: Modify Here, Please  
 */

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.Reports.Dashboard.Models;
using BionicERP.Application.Interfaces;
using BionicShipment.Application.Models;
using MediatR;
namespace BionicERP.Application.Crm.Reports.Dashboard {
    public class GetCrmDashbordViewQueryHandler : IRequestHandler<GetCrmDashbordViewQuery, DashboardViewModel> {

        private readonly IBionicERPDatabaseService _database;

        public GetCrmDashbordViewQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<DashboardViewModel> Handle (GetCrmDashbordViewQuery request, CancellationToken cancellationToken) {
            DashboardViewModel result = new DashboardViewModel ();

            result.TotalCustomers = _database.Customer.Count ();
            result.TotalCustomerOrders = _database.CustomerOrder.Count ();
            result.TotalInvoices = _database.Invoice.Count ();

            return Task.FromResult<DashboardViewModel> (result);
        }
    }

}