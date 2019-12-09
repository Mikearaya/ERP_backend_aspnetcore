/*
 * @CreateTime: Dec 9, 2019 7:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2019 7:06 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class DeleteCustomerPhoneCommandHandler : IRequestHandler<DeleteCustomerPhoneCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteCustomerPhoneCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteCustomerPhoneCommand request, CancellationToken cancellationToken) {
            PhoneNumber phone = await _database.PhoneNumber
                .FirstOrDefaultAsync (c => c.ClientId == request.CustomerId && c.Id == request.Id);

            if (phone == null) {
                throw new NotFoundException ("Customer phone number", request.Id);
            }

            _database.PhoneNumber.Remove (phone);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}