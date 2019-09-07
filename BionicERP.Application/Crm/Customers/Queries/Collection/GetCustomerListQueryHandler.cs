/*
 * @CreateTime: Sep 7, 2019 5:33 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 6:09 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.Customers.Models;
using BionicERP.Application.Interfaces;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Crm.Customers.Queries {
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, FilterResultModel<CustomerListViewModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetCustomerListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<CustomerListViewModel>> Handle (GetCustomerListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "FullName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<CustomerListViewModel> result = new FilterResultModel<CustomerListViewModel> ();
            var customer = _database.Customer
                .Select (CustomerListViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<CustomerListViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                customer = customer
                    .Where (DynamicQueryHelper
                        .BuildWhere<CustomerListViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = customer.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = customer.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<CustomerListViewModel>> (result);
        }
    }
}