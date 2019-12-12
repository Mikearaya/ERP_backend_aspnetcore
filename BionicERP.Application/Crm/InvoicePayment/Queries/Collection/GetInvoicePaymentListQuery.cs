/*
 * @CreateTime: Dec 12, 2019 11:52 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 11:53 AM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Crm.InvoicePayment.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Crm.InvoicePayment.Queries {
    public class GetInvoicePaymentListQuery : ApiQueryString, IRequest<FilterResultModel<InvoicePaymentListView>> {

    }
}