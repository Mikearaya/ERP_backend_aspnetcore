/*
 * @CreateTime: Aug 23, 2019 2:16 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 12:21 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.ProductGroups.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.ProductGroups.Queries {
    public class GetProductGroupListQueryHandler : IRequestHandler<GetProductGroupListQuery, FilterResultModel<ProductGroupViewModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetProductGroupListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<ProductGroupViewModel>> Handle (GetProductGroupListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "GroupName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? false : true;

            FilterResultModel<ProductGroupViewModel> result = new FilterResultModel<ProductGroupViewModel> ();
            var productGroup = _database.ProductGroup
                .Select (ProductGroupViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<ProductGroupViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                productGroup = productGroup
                    .Where (DynamicQueryHelper
                        .BuildWhere<ProductGroupViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = productGroup.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = productGroup.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<ProductGroupViewModel>> (result);
        }
    }
}