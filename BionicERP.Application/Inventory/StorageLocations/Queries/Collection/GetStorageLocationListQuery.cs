/*
 * @CreateTime: Aug 24, 2019 11:09 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 11:10 AM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.StorageLocations.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.StorageLocations.Queries {
    public class GetStorageLocationListQuery : ApiQueryString, IRequest<FilterResultModel<StorageLocationViewModel>> {

    }
}