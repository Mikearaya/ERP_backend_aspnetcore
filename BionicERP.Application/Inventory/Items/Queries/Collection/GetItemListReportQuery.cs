/*
 * @CreateTime: Aug 24, 2019 12:19 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 24, 2019 12:19 PM 
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.Items.Models;
using BionicERP.Commons.QueryHelpers;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicERP.Application.Inventory.Items.Queries {
    public class GetItemListReportQuery : ApiQueryString, IRequest<FilterResultModel<ItemReportListView>> {

    }
}