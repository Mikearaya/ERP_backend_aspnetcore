/*
 * @CreateTime: Aug 24, 2019 11:04 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 24, 2019 11:04 AM 
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.StorageLocations.Commands {
    public class DeleteStorageLocationCommandHandler : IRequestHandler<DeleteStorageLocationCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteStorageLocationCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteStorageLocationCommand request, CancellationToken cancellationToken) {
            StorageLocation storage = await _database.StorageLocation.FindAsync (request.Id);

            if (storage == null) {
                throw new NotFoundException ("Storage Location", request.Id);
            }

            _database.StorageLocation.Remove (storage);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}