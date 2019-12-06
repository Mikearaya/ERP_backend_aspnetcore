using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.Items.Models;
using BionicERP.Application.Inventory.StockBatchs.Models;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.StockBatchs.Queries {
    public class GetInventoryViewQueryHandler : IRequestHandler<GetInventoryViewQuery, FilterResultModel<InventoryView>> {
        private readonly IBionicERPDatabaseService _database;

        public GetInventoryViewQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<InventoryView>> Handle (GetInventoryViewQuery request, CancellationToken cancellationToken) {

            FilterResultModel<InventoryView> result = new FilterResultModel<InventoryView> ();

            result.Items = _database.Item
                .Include (i => i.PrimaryUom)
                .GroupJoin (_database.StockBatchStorage, item => item.Id,
                    lot => lot.Batch.ItemId,
                    (product, lot) => new ItemLotJoin () {
                        Item = product,
                            Lot = lot,
                            uom = product.PrimaryUom.Abrivation,
                            group = product.Group.GroupName
                    }).GroupBy (i => i.Item)
                .Select (InventoryView.Projection)
                .ToList ();
            result.Count = result.Items.Count ();

            return Task.FromResult<FilterResultModel<InventoryView>> (result);
        }
    }
}