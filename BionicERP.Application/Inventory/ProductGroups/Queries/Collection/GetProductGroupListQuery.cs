/*
 * @CreateTime: Aug 23, 2019 2:14 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:32 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.ProductGroups.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.ProductGroups {
    public class GetProductGroupListQuery : ApiQueryString, IRequest<FilterResultModel<ProductGroupViewModel>> {

    }
}