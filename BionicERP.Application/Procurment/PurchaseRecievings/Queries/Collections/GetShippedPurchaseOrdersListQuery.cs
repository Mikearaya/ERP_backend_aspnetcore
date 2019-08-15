/*
 * @CreateTime: Aug 9, 2019 8:34 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 9, 2019 8:34 PM 
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Procurment.PurchaseOrders.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseRecievings.Queries {
    public class GetShippedPurchaseOrdersListQuery : ApiQueryString, IRequest<FilterResultModel<PurchaseOrderView>> {

    }
}