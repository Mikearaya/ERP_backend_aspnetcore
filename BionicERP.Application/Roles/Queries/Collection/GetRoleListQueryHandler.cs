/*
 * @CreateTime: Sep 9, 2019 5:53 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:55 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Roles.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Roles.Queries {
    public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, FilterResultModel<RoleViewModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetRoleListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<RoleViewModel>> Handle (GetRoleListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "Name";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<RoleViewModel> result = new FilterResultModel<RoleViewModel> ();
            var role = _database.Roles
                .Select (RoleViewModel.ClaimLessProjection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<RoleViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                role = role
                    .Where (DynamicQueryHelper
                        .BuildWhere<RoleViewModel> (request.Filter)).AsQueryable ();

            }

            result.Count = role.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = role.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<RoleViewModel>> (result);
        }
    }
}