/*
 * @CreateTime: Sep 7, 2019 4:10 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 4:11 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.Shipments.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.Shipments.Queries {
    public class GetShipmentByIdQueryHandler : IRequestHandler<GetShipmentByIdQuery, ShipmentDetailViewModel> {
        private readonly IBionicERPDatabaseService _database;

        public GetShipmentByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<ShipmentDetailViewModel> Handle (GetShipmentByIdQuery request, CancellationToken cancellationToken) {
            ShipmentDetailViewModel shipment = await _database.Shipment
                .Where (s => s.Id == request.Id)
                .Select (ShipmentDetailViewModel.Projection)
                .FirstOrDefaultAsync ();

            if (shipment == null) {
                throw new NotFoundException ("Shipment", request.Id);
            }

            return shipment;
        }
    }
}