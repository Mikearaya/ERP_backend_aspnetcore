/*
 * @CreateTime: Sep 7, 2019 4:09 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 4:10 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.Shipments.Models;
using MediatR;

namespace BionicERP.Application.Inventory.Shipments.Queries {
    public class GetShipmentByIdQuery : IRequest<ShipmentDetailViewModel> {

        public uint Id { get; set; }

    }
}