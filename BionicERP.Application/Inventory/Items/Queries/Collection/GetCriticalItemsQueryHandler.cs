/*
 * @CreateTime: Aug 24, 2019 12:25 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 12:27 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.Items.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.Items.Queries {
    public class GetCriticalItemsQueryHandler : IRequestHandler<GetCriticalItemsQuery, FilterResultModel<CriticalItemsView>> {
        private readonly IBionicERPDatabaseService _database;

        public GetCriticalItemsQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<CriticalItemsView>> Handle (GetCriticalItemsQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "ItemName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<CriticalItemsView> result = new FilterResultModel<CriticalItemsView> ();
            var itemList = _database.Item
                .Include (i => i.PrimaryUom)
                .GroupJoin (_database.StockBatchStorage, item => item.Id,
                    lot => lot.Batch.ItemId,
                    (product, slot) => new ItemLotJoin () {
                        Item = product,
                            Lot = slot
                    }).GroupBy (i => i.Item)
                .Select (CriticalItemsView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<CriticalItemsView> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                itemList = itemList
                    .Where (DynamicQueryHelper
                        .BuildWhere<CriticalItemsView> (request.Filter)).AsQueryable ();
            }

            result.Count = itemList.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = itemList.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<CriticalItemsView>> (result);
        }
    }
}