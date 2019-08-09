/*
 * @CreateTime: Dec 23, 2018 11:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:57 PM
 * @Description: Modify Here, Please 
 */

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Commons.QueryHelpers;
using BionicInventory.Application.Procurment.Vendors.Models;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicInventory.Application.Procurment.Vendors.Queries {

    public class GetVendorsListViewQueryHandler : IRequestHandler<GetVendorsListQuery, FilterResultModel<VendorView>> {
        private IBionicERPDatabaseService _database;

        public GetVendorsListViewQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<VendorView>> Handle (GetVendorsListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Name";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<VendorView> result = new FilterResultModel<VendorView> ();
            var vendor = _database.Vendor
                .Select (VendorView.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<VendorView> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                vendor = vendor
                    .Where (DynamicQueryHelper
                        .BuildWhere<VendorView> (request.Filter)).AsQueryable ();
            }

            result.Count = vendor.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = vendor.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<VendorView>> (result);
        }
    }
}