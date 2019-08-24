/*
 * @CreateTime: Aug 24, 2019 5:08 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 5:09 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.StockBatchs.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.StockBatchs.Queries {
    public class GetStockBatchListQuery : ApiQueryString, IRequest<FilterResultModel<StockBatchViewModel>> {

    }
}