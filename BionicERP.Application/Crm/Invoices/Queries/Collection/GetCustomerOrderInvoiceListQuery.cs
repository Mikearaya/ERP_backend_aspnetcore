/*
 * @CreateTime: Dec 11, 2019 1:24 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 1:28 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Crm.Invoices.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Crm.Invoices.Queries {
    public class GetCustomerOrderInvoiceListQuery : ApiQueryString, IRequest<FilterResultModel<CustomerOrderInvoiceList>> {

    }
}