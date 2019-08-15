/*
 * @CreateTime: Aug 9, 2019 8:35 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 8:38 PM
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
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Procurment.PurchaseRecievings.Queries {
    public class GetShippedPurchaseOrdersListQueryHandler : IRequestHandler<GetShippedPurchaseOrdersListQuery, FilterResultModel<PurchaseOrderView>> {
        private readonly IBionicERPDatabaseService _database;

        public GetShippedPurchaseOrdersListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<PurchaseOrderView>> Handle (GetShippedPurchaseOrdersListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "DateAdded";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<PurchaseOrderView> result = new FilterResultModel<PurchaseOrderView> ();
            var purchaseTerm = _database.PurchaseOrder
                .Where (p => p.Status.ToUpper () == "SHIPPED")
                .Include (p => p.PurchaseOrderQuotation)
                .Include (p => p.StockBatch)
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