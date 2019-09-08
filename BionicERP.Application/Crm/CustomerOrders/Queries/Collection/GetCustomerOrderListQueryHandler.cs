/*
 * @CreateTime: Sep 8, 2019 5:05 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:07 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.CustomerOrders.Models;
using BionicERP.Application.Interfaces;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Crm.CustomerOrders.Queries {
    public class GetCustomerOrderListQueryHandler : IRequestHandler<GetCustomerOrderListQuery, FilterResultModel<CustomerOrderListViewModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetCustomerOrderListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<CustomerOrderListViewModel>> Handle (GetCustomerOrderListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "DateAdded";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<CustomerOrderListViewModel> result = new FilterResultModel<CustomerOrderListViewModel> ();
            var customer = _database.CustomerOrder
                .Select (CustomerOrderListViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<CustomerOrderListViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                customer = customer
                    .Where (DynamicQueryHelper
                        .BuildWhere<CustomerOrderListViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = customer.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = customer.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<CustomerOrderListViewModel>> (result);
        }
    }
}