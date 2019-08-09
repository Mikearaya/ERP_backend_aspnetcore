/*
 * @CreateTime: Aug 5, 2019 9:55 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:58 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Procurment.PurchaseTerms.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseTerms.Queries {
    public class GetPurchaseTermsListQueryHandler : IRequestHandler<GetPurchaseTermsListQuery, FilterResultModel<PurchaseTermViewModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetPurchaseTermsListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<PurchaseTermViewModel>> Handle (GetPurchaseTermsListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Item";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<PurchaseTermViewModel> result = new FilterResultModel<PurchaseTermViewModel> ();
            var purchaseTerm = _database.VendorPurchaseTerm
                .Select (PurchaseTermViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<PurchaseTermViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                purchaseTerm = purchaseTerm
                    .Where (DynamicQueryHelper
                        .BuildWhere<PurchaseTermViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = purchaseTerm.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = purchaseTerm.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<PurchaseTermViewModel>> (result);
        }
    }
}