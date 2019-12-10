/*
 * @CreateTime: Dec 24, 2018 9:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 10, 2019 4:11 PM
 * @Description: Modify Here, Please 
 */
using BionicERP.Application.Procurment.Vendors.Models;
using BionicInventory.Application.Procurment.Vendors.Models;
using MediatR;

namespace BionicInventory.Application.Procurment.Vendors.Queries {
    public class GetVendorByIdQuery : IRequest<VendorView> {
        public uint Id { get; set; }
    }
}