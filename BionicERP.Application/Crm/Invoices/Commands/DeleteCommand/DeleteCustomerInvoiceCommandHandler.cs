/*
 * @CreateTime: Dec 11, 2019 2:59 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 3:02 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.Invoices.Commands {
    public class DeleteCustomerInvoiceCommandHandler : IRequestHandler<DeleteCustomerInvoiceCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteCustomerInvoiceCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteCustomerInvoiceCommand request, CancellationToken cancellationToken) {
            Invoice invoice = await _database.Invoice
                .Where (i => i.Id == request.Id)
                .Include (d => d.InvoiceDetail)
                .FirstOrDefaultAsync ();

            if (invoice == null) {
                throw new NotFoundException ("Customer Invoice", request.Id);
            }

            _database.Invoice.Remove (invoice);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}