/*
 * @CreateTime: Sep 7, 2019 4:06 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 7, 2019 4:06 PM 
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.Shipments.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.Shipments.Queries {
    public class GetShipmentListQuery : ApiQueryString, IRequest<FilterResultModel<ShipmentListViewModel>> {

    }
}