/*
 * @CreateTime: Sep 7, 2019 4:06 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 4:09 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.Shipments.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.Shipments.Queries {
    public class GetShipmentListQueryHandler : IRequestHandler<GetShipmentListQuery, FilterResultModel<ShipmentListViewModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetShipmentListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<ShipmentListViewModel>> Handle (GetShipmentListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "DateAdded";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<ShipmentListViewModel> result = new FilterResultModel<ShipmentListViewModel> ();
            var shipment = _database.Shipment
                .Select (ShipmentListViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<ShipmentListViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                shipment = shipment
                    .Where (DynamicQueryHelper
                        .BuildWhere<ShipmentListViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = shipment.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = shipment.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<ShipmentListViewModel>> (result);
        }
    }
}