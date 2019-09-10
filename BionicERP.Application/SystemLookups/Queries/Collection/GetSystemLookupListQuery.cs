/*
 * @CreateTime: Sep 10, 2019 12:35 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:36 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.SystemLookups.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.SystemLookups.Queries {
    public class GetSystemLookupListQuery : ApiQueryString, IRequest<FilterResultModel<SystemLookupViewModel>> {

    }
}