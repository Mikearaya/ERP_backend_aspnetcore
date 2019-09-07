/*
 * @CreateTime: Sep 7, 2019 5:09 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:12 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteCustomerCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteCustomerCommand request, CancellationToken cancellationToken) {
            Customer customer = await _database.Customer.FindAsync (request.Id);

            if (customer == null) {
                throw new NotFoundException ("Customer", request.Id);
            }

            _database.Customer.Remove (customer);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}