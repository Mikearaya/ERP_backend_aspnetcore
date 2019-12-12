/*
 * @CreateTime: Dec 12, 2019 11:55 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 1:32 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.InvoicePayment.Models;
using BionicERP.Application.Interfaces;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Crm.InvoicePayment.Queries {
    public class GetInvoicePaymentListQueryHandler : IRequestHandler<GetInvoicePaymentListQuery, FilterResultModel<InvoicePaymentListView>> {
        private readonly IBionicERPDatabaseService _database;

        public GetInvoicePaymentListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<InvoicePaymentListView>> Handle (GetInvoicePaymentListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "DateAdded";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<InvoicePaymentListView> result = new FilterResultModel<InvoicePaymentListView> ();
            var invoicePayment = _database.InvoicePayments
                .Where (i => i.InvoiceNoNavigation != null)
                .Select (InvoicePaymentListView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<InvoicePaymentListView> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                invoicePayment = invoicePayment
                    .Where (DynamicQueryHelper
                        .BuildWhere<InvoicePaymentListView> (request.Filter)).AsQueryable ();
            }

            result.Count = invoicePayment.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = invoicePayment.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<InvoicePaymentListView>> (result);
        }
    }
}