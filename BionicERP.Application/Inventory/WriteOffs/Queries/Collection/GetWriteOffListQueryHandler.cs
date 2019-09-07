using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.WriteOffs.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.WriteOffs.Queries {
    public class GetWriteOffListQueryHandler : IRequestHandler<GetWriteOffListQuery, FilterResultModel<WriteOffViewModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetWriteOffListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<WriteOffViewModel>> Handle (GetWriteOffListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "DateAdded";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<WriteOffViewModel> result = new FilterResultModel<WriteOffViewModel> ();
            var writeOff = _database.WriteOff
                .Select (WriteOffViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<WriteOffViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                writeOff = writeOff
                    .Where (DynamicQueryHelper
                        .BuildWhere<WriteOffViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = writeOff.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = writeOff.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<WriteOffViewModel>> (result);
        }
    }
}