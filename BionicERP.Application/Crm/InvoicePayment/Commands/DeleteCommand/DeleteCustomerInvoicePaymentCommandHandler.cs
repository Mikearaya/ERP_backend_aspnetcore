/*
 * @CreateTime: Dec 12, 2019 2:13 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Dec 12, 2019 2:13 PM 
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;

namespace BionicERP.Application.Crm.InvoicePayment.Commands {
    public class DeleteCustomerInvoicePaymentCommandHandler : IRequestHandler<DeleteCustomerInvoicePaymentCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteCustomerInvoicePaymentCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteCustomerInvoicePaymentCommand request, CancellationToken cancellationToken) {
            InvoicePayments payments = await _database.InvoicePayments.FindAsync (request.Id);

            if (payments == null) {
                throw new NotFoundException ("Customer Invoice Payment", request.Id);
            }

            _database.InvoicePayments.Remove (payments);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}