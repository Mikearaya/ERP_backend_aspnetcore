/*
 * @CreateTime: Sep 10, 2019 9:18 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:19 AM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Users.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Users.Queries {
    public class GetUserListQuery : ApiQueryString, IRequest<FilterResultModel<UserViewModel>> {

    }
}