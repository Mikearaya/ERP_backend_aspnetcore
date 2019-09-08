/*
 * @CreateTime: Sep 8, 2019 5:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:04 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Crm.CustomerOrders.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Crm.CustomerOrders.Queries {
    public class GetCustomerOrderListQuery : ApiQueryString, IRequest<FilterResultModel<CustomerOrderListViewModel>> {

    }
}