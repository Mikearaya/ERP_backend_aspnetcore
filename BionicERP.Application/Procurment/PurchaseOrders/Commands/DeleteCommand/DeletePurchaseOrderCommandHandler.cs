/*
 * @CreateTime: Aug 9, 2019 2:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 2:04 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrders.Commands {
    public class DeletePurchaseOrderCommandHandler : IRequestHandler<DeletePurchaseOrderCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeletePurchaseOrderCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletePurchaseOrderCommand request, CancellationToken cancellationToken) {
            var purchaseOrder = await _database
                .PurchaseOrder
                .FindAsync (request.Id);

            if (purchaseOrder == null) {
                throw new NotFoundException ("Purchase Order", request.Id);
            }

            _database.PurchaseOrder.Remove (purchaseOrder);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}