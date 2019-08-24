/*
 * @CreateTime: Aug 24, 2019 5:09 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 5:12 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.StockBatchs.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.StockBatchs.Queries {
    public class GetStockBatchListQueryHandler : IRequestHandler<GetStockBatchListQuery, FilterResultModel<StockBatchViewModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetStockBatchListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<StockBatchViewModel>> Handle (GetStockBatchListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "DateAdded";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<StockBatchViewModel> result = new FilterResultModel<StockBatchViewModel> ();
            var batch = _database.StockBatchStorage
                .Select (StockBatchViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<StockBatchViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                batch = batch
                    .Where (DynamicQueryHelper
                        .BuildWhere<StockBatchViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = batch.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = batch.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<StockBatchViewModel>> (result);
        }
    }
}