/*
 * @CreateTime: Aug 24, 2019 5:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 5:03 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using MediatR;

namespace BionicERP.Application.Inventory.StockBatchs.Commands {
    public class DeleteStockBatchCommandHandler : IRequestHandler<DeleteStockBatchCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteStockBatchCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteStockBatchCommand request, CancellationToken cancellationToken) {
            var batch = await _database.StockBatchStorage.FindAsync (request.Id);

            if (batch == null) {
                throw new NotFoundException ("Batch", request.Id);
            }

            _database.StockBatchStorage.Remove (batch);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}