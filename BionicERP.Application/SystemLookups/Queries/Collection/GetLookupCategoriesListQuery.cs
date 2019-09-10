/*
 * @CreateTime: May 12, 2019 2:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:39 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicERP.Application.SystemLookups.Models;
using BionicERP.Commons.QueryHelpers;
using MediatR;

namespace BionicERP.Application.SystemLookups.Queries {
    public class GetSystemLookupCategoriesListQuery : ApiQueryString, IRequest<IEnumerable<SystemLookupCategoryIndexModel>> {

    }
}