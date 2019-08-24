/*
 * @CreateTime: Aug 23, 2019 2:58 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 10:39 AM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Commands {
    public class DeleteUnitOfMeasurmentCommandHandler : IRequestHandler<DeleteUnitOfMeasurmentCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteUnitOfMeasurmentCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteUnitOfMeasurmentCommand request, CancellationToken cancellationToken) {
            UnitOfMeasurment uom = await _database.UnitsOfMeasurment.FindAsync (request.Id);

            if (uom == null) {
                throw new NotFoundException ("UOM", request.Id);
            }

            _database.UnitsOfMeasurment.Remove (uom);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}