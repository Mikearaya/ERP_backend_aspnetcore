/*
 * @CreateTime: Sep 9, 2019 5:53 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 9, 2019 5:53 PM 
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Roles.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Roles.Queries {
    public class GetRoleListQuery : ApiQueryString, IRequest<FilterResultModel<RoleViewModel>> {

    }
}