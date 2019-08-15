/*
 * @CreateTime: Aug 15, 2019 7:53 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 7:54 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Procurment.PurchaseOrderPayments.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Queries {
    public class GetPurchaseOrderPyamentListQuery : ApiQueryString, IRequest<FilterResultModel<PurchaseOrderPaymentView>> {

    }
}