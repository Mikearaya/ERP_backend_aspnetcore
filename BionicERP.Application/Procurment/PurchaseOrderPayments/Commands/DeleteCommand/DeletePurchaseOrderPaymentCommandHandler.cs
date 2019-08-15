/*
 * @CreateTime: Aug 15, 2019 7:42 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 8:02 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Commands {
    public class DeletePurchaseOrderPaymentCommandHandler : IRequestHandler<DeletePurchaseOrderPaymentCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeletePurchaseOrderPaymentCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletePurchaseOrderPaymentCommand request, CancellationToken cancellationToken) {
            InvoicePayments payment = await _database.InvoicePayments.FindAsync (request.Id);

            if (payment == null) {
                throw new NotFoundException ("Payment", request.Id);
            }

            _database.InvoicePayments.Remove (payment);
            await _database.SaveAsync ();
            return Unit.Value;
        }
    }
}