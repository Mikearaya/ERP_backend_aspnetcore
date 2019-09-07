/*
 * @CreateTime: Sep 7, 2019 1:22 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:23 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.WriteOffs.Commands {
    public class DeleteWriteOffCommadHandler : IRequestHandler<DeleteWriteOffCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteWriteOffCommadHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteWriteOffCommand request, CancellationToken cancellationToken) {
            WriteOff writeOff = await _database.WriteOff
                .Include (w => w.WriteOffDetail)
                .FirstOrDefaultAsync (w => w.Id == request.Id);

            if (writeOff == null) {
                throw new NotFoundException (nameof (WriteOff), request.Id);
            }

            // add the writen off value back to storage lot location quantity
            foreach (var item in writeOff.WriteOffDetail) {
                var storage = await _database.StockBatchStorage.FindAsync (item.BatchStorageId);
                storage.Quantity += item.Quantity;
                _database.StockBatchStorage.Update (storage);
            }

            _database.WriteOff.Remove (writeOff);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}