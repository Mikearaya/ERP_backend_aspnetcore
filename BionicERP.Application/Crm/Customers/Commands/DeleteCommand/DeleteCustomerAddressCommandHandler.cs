/*
 * @CreateTime: Dec 9, 2019 6:28 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2019 6:41 PM
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

namespace BionicERP.Application.Crm.Customers.Commands {
    public class DeleteCustomerAddressCommandHandler : IRequestHandler<DeleteCustomerAddressCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteCustomerAddressCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteCustomerAddressCommand request, CancellationToken cancellationToken) {
            Address customerAddress = await _database.Address.FirstOrDefaultAsync (c => c.Id == request.Id && c.ClientId == request.CustomerId);

            if (customerAddress == null) {
                throw new NotFoundException ("Customer Address", request.Id);
            }

            _database.Address.Remove (customerAddress);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}