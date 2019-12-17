/*
 * @CreateTime: Dec 17, 2019 8:08 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 17, 2019 8:11 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Procurment.Reports.Dashboard.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Procurment.Reports.Dashboard {
    public class GetProcurmentSummaryViewQueryHandler : IRequestHandler<GetProcurmentSummaryViewQuery, ProcurmentSummaryViewModel> {
        private readonly IBionicERPDatabaseService _database;

        public GetProcurmentSummaryViewQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<ProcurmentSummaryViewModel> Handle (GetProcurmentSummaryViewQuery request, CancellationToken cancellationToken) {
            ProcurmentSummaryViewModel result = new ProcurmentSummaryViewModel ();

            result.TotalVendors = await _database.Vendor.CountAsync ();
            result.TotalPurchaseOrders = await _database.PurchaseOrder.CountAsync ();
            return result;
        }
    }
}