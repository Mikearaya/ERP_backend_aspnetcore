/*
 * @CreateTime: Sep 7, 2019 3:59 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 7, 2019 3:59 PM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Inventory.Shipments.Commands {
    public class DeleteShipmentCommand : IRequest {
        public uint Id { get; set; }
    }
}