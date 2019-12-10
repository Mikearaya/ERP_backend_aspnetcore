using System.Collections.Generic;
using BionicERP.Application.Procurment.Vendors.Models;
/*
 * @CreateTime: Dec 10, 2019 3:55 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 10, 2019 4:00 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Procurment.Vendors.Queries {
    public class GetVendorPurchaseTermQuery : IRequest<IEnumerable<VendorPurchaseTermView>> {
        public uint VendorId { get; set; }
    }
}