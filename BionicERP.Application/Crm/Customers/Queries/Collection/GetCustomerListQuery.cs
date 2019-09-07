/*
 * @CreateTime: Sep 7, 2019 5:33 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 6:04 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Crm.Customers.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Crm.Customers.Queries {
    public class GetCustomerListQuery : ApiQueryString, IRequest<FilterResultModel<CustomerListViewModel>> {

    }
}