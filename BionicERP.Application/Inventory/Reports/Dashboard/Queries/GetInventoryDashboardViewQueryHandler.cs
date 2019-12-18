/*
 * @CreateTime: Dec 18, 2019 8:40 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 18, 2019 8:53 AM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.Reports.Dashboard.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.Reports.Dashboard {
    public class GetInventoryDashboardViewQueryHandler : IRequestHandler<GetInventoryDashboardViewQuery, InventoryDashboardSummaryView> {
        private readonly IBionicERPDatabaseService _database;

        public GetInventoryDashboardViewQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<InventoryDashboardSummaryView> Handle (GetInventoryDashboardViewQuery request, CancellationToken cancellationToken) {
            InventoryDashboardSummaryView result = new InventoryDashboardSummaryView ();
            result.TotalItems = await _database.Item.CountAsync ();
            result.TotalRecievedItems = (decimal) _database.StockBatch.Where (i => i.Status.ToUpper () == "RECIEVED").Sum (i => (decimal) i.Quantity);
            result.TotalPlannedItems = (decimal) _database.StockBatch.Where (i => i.Status.ToUpper () == "PLANED").Sum (i => (decimal) i.Quantity);
            result.TotalBookedShippings = (decimal) await _database.ShipmentDetail.SumAsync (i => i.BookedQuantity);
            result.TotalPickedShippings = (decimal) await _database.ShipmentDetail.SumAsync (i => i.PickedQuantity);

            return result;

        }
    }
}