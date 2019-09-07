/*
 * @CreateTime: Sep 7, 2019 4:00 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 4:02 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.Shipments.Commands {
    public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteShipmentCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteShipmentCommand request, CancellationToken cancellationToken) {
            Shipment shipment = await _database.Shipment
                .FindAsync (request.Id);

            if (shipment == null) {
                throw new NotFoundException (nameof (Shipment), request.Id);
            }

            _database.Shipment.Remove (shipment);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}