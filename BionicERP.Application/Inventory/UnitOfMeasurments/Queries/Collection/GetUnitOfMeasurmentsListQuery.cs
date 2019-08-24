/*
 * @CreateTime: Aug 23, 2019 3:01 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 23, 2019 3:01 PM 
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.UnitOfMeasurments.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Queries {
    public class GetUnitOfMeasurmentsListQuery : ApiQueryString, IRequest<FilterResultModel<UnitOfMeasurmentViewModel>> {

    }
}