/*
 * @CreateTime: Dec 24, 2018 9:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:26 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Procurment.Vendors.Models;
using MediatR;

namespace BionicInventory.Application.Procurment.Vendors.Queries {
    public class GetVendorByIdQuery : IRequest<VendorView> {
        public uint Id { get; set; }
    }
}