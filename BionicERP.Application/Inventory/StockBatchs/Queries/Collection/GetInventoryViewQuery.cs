using System.Collections.Generic;
/*
 * @CreateTime: Dec 6, 2019 5:41 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 6, 2019 6:21 PM
 * @Description: Modify Here, Please  
 */

using BionicERP.Application.Inventory.StockBatchs.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.StockBatchs.Queries {

    public class GetInventoryViewQuery : ApiQueryString, IRequest<FilterResultModel<InventoryView>> {

    }

}