/*
 * @CreateTime: Aug 5, 2019 9:54 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:55 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Procurment.PurchaseTerms.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseTerms.Queries {
    public class GetPurchaseTermsListQuery : ApiQueryString, IRequest<FilterResultModel<PurchaseTermViewModel>> {

    }
}