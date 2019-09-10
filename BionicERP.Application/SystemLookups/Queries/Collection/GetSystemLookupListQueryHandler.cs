/*
 * @CreateTime: Sep 10, 2019 12:36 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:38 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.SystemLookups.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.SystemLookups.Queries {
    public class GetSystemLookupListQueryHandler : IRequestHandler<GetSystemLookupListQuery, FilterResultModel<SystemLookupViewModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetSystemLookupListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<SystemLookupViewModel>> Handle (GetSystemLookupListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Type";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<SystemLookupViewModel> result = new FilterResultModel<SystemLookupViewModel> ();
            var lookup = _database.SystemLookups
                .Where (l => l.Type.ToLower () != "system_lookup")
                .Select (SystemLookupViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<SystemLookupViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                lookup = lookup
                    .Where (DynamicQueryHelper
                        .BuildWhere<SystemLookupViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = lookup.Count ();

            result.Items = lookup.OrderBy (sortBy, sortDirection).Skip (request.PageNumber)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<SystemLookupViewModel>> (result);
        }
    }
}