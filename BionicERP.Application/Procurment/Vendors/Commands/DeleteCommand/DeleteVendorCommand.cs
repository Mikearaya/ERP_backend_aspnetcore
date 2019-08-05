/*
 * @CreateTime: Dec 23, 2018 10:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:05 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicERP.Application.Procurment.Vendors.Commands {
    public class DeleteVendorCommand : IRequest {
        public uint Id { get; set; }
    }
}