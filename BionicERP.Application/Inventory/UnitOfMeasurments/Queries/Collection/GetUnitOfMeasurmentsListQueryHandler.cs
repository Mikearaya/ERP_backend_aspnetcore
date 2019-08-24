/*
 * @CreateTime: Aug 23, 2019 3:02 PM 
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
using BionicERP.Application.Inventory.UnitOfMeasurments.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Queries {
    public class GetUnitOfMeasurmentsListQueryHandler : IRequestHandler<GetUnitOfMeasurmentsListQuery, FilterResultModel<UnitOfMeasurmentViewModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetUnitOfMeasurmentsListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<UnitOfMeasurmentViewModel>> Handle (GetUnitOfMeasurmentsListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Name";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<UnitOfMeasurmentViewModel> result = new FilterResultModel<UnitOfMeasurmentViewModel> ();
            var uom = _database.UnitsOfMeasurment
                .Select (UnitOfMeasurmentViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<UnitOfMeasurmentViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                uom = uom
                    .Where (DynamicQueryHelper
                        .BuildWhere<UnitOfMeasurmentViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = uom.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = uom.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<UnitOfMeasurmentViewModel>> (result);
        }
    }
}