/*
 * @CreateTime: Aug 24, 2019 11:10 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 11:12 AM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.StorageLocations.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.StorageLocations.Queries {
    public class GetStorageLocationListQueryHandler : IRequestHandler<GetStorageLocationListQuery, FilterResultModel<StorageLocationViewModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetStorageLocationListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<StorageLocationViewModel>> Handle (GetStorageLocationListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Name";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<StorageLocationViewModel> result = new FilterResultModel<StorageLocationViewModel> ();
            var storage = _database.StorageLocation
                .Select (StorageLocationViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<StorageLocationViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                storage = storage
                    .Where (DynamicQueryHelper
                        .BuildWhere<StorageLocationViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = storage.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = storage.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<StorageLocationViewModel>> (result);
        }
    }
}