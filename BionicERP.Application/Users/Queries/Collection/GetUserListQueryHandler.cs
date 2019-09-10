/*
 * @CreateTime: Sep 10, 2019 9:20 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:22 AM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Users.Models;
using BionicERP.Commons.QueryHelpers;
using BionicERP.Domain.Identity;
using BionicShipment.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BionicERP.Application.Users.Queries {
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, FilterResultModel<UserViewModel>> {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserListQueryHandler (UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public Task<FilterResultModel<UserViewModel>> Handle (GetUserListQuery request, CancellationToken cancellationToken) {
            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "UserName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<UserViewModel> result = new FilterResultModel<UserViewModel> ();
            var vehicle = _userManager.Users
                .Select (UserViewModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<UserViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                vehicle = vehicle
                    .Where (DynamicQueryHelper
                        .BuildWhere<UserViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = vehicle.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = vehicle.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<UserViewModel>> (result);
        }
    }
}