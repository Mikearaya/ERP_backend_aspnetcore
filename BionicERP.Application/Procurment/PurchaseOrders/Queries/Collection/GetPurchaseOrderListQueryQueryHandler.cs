/*
 * @CreateTime: Aug 9, 2019 2:08 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 2:11 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Procurment.PurchaseOrders.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrders.Queries {
    public class GetPurchaseOrderListQueryQueryHandler : IRequestHandler<GetPurchaseOrderListQuery, FilterResultModel<PurchaseOrderView>> {
        private readonly IBionicERPDatabaseService _database;

        public GetPurchaseOrderListQueryQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<PurchaseOrderView>> Handle (GetPurchaseOrderListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "DateAdded";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<PurchaseOrderView> result = new FilterResultModel<PurchaseOrderView> ();
            var purchaseTerm = _database.PurchaseOrder
                .Select (PurchaseOrderView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<PurchaseOrderView> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                purchaseTerm = purchaseTerm
                    .Where (DynamicQueryHelper
                        .BuildWhere<PurchaseOrderView> (request.Filter)).AsQueryable ();
            }

            result.Count = purchaseTerm.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = purchaseTerm.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<PurchaseOrderView>> (result);
        }
    }
}