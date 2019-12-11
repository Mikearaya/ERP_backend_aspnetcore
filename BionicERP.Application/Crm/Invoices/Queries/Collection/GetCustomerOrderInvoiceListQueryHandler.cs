/*
 * @CreateTime: Dec 11, 2019 1:25 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 1:32 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.Invoices.Models;
using BionicERP.Application.Interfaces;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Crm.Invoices.Queries {
    public class GetCustomerOrderInvoiceListQueryHandler : IRequestHandler<GetCustomerOrderInvoiceListQuery, FilterResultModel<CustomerOrderInvoiceList>> {
        private readonly IBionicERPDatabaseService _database;

        public GetCustomerOrderInvoiceListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<CustomerOrderInvoiceList>> Handle (GetCustomerOrderInvoiceListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "CustomerName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<CustomerOrderInvoiceList> result = new FilterResultModel<CustomerOrderInvoiceList> ();
            var invoice = _database.Invoice
                .Select (CustomerOrderInvoiceList.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<CustomerOrderInvoiceList> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                invoice = invoice
                    .Where (DynamicQueryHelper
                        .BuildWhere<CustomerOrderInvoiceList> (request.Filter)).AsQueryable ();
            }

            result.Count = invoice.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = invoice.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<CustomerOrderInvoiceList>> (result);
        }
    }
}