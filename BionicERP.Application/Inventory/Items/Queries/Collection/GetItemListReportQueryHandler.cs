/*
 * @CreateTime: Aug 24, 2019 12:19 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 12:23 PM
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
    public class GetItemListReportQueryHandler : IRequestHandler<GetItemListReportQuery, FilterResultModel<ItemReportListView>> {
        private readonly IBionicERPDatabaseService _database;

        public GetItemListReportQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<ItemReportListView>> Handle (GetItemListReportQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Item";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<ItemReportListView> result = new FilterResultModel<ItemReportListView> ();
            var itemList = _database.Item
                .Include (i => i.PrimaryUom)
                .GroupJoin (_database.StockBatchStorage, item => item.Id,
                    lot => lot.Batch.ItemId,
                    (product, slot) => new ItemLotJoin () {
                        Item = product,
                            Lot = slot
                    }).GroupBy (i => i.Item)
                .Select (ItemReportListView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<ItemReportListView> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                itemList = itemList
                    .Where (DynamicQueryHelper
                        .BuildWhere<ItemReportListView> (request.Filter)).AsQueryable ();
            }

            result.Count = itemList.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = itemList.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<ItemReportListView>> (result);
        }
    }
}