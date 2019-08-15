/*
 * @CreateTime: Aug 15, 2019 7:54 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 7:57 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Procurment.PurchaseOrderPayments.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Queries {
    public class GetPurchaseOrderPyamentListQueryHandler : IRequestHandler<GetPurchaseOrderPyamentListQuery, FilterResultModel<PurchaseOrderPaymentView>> {
        private readonly IBionicERPDatabaseService _database;

        public GetPurchaseOrderPyamentListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<PurchaseOrderPaymentView>> Handle (GetPurchaseOrderPyamentListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "DateAdded";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<PurchaseOrderPaymentView> result = new FilterResultModel<PurchaseOrderPaymentView> ();
            var payment = _database.InvoicePayments
                .Select (PurchaseOrderPaymentView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<PurchaseOrderPaymentView> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                payment = payment
                    .Where (DynamicQueryHelper
                        .BuildWhere<PurchaseOrderPaymentView> (request.Filter)).AsQueryable ();
            }

            result.Count = payment.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = payment.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<PurchaseOrderPaymentView>> (result);
        }
    }
}