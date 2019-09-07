/*
 * @CreateTime: Sep 7, 2019 1:32 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:34 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.WriteOffs.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.WriteOffs.Queries {
    public class GetWriteOffListQuery : ApiQueryString, IRequest<FilterResultModel<WriteOffViewModel>> {

    }
}