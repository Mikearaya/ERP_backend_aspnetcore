/*
 * @CreateTime: Dec 23, 2018 11:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:25 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicERP.Commons.QueryHelpers;
using BionicInventory.Application.Procurment.Vendors.Models;
using BionicShipment.Application.Models;
using MediatR;

namespace BionicInventory.Application.Procurment.Vendors.Queries {
    public class GetVendorsListQuery : ApiQueryString, IRequest<FilterResultModel<VendorView>> {

    }
}