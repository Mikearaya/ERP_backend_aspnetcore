/*
 * @CreateTime: Sep 8, 2019 4:48 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 4:50 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;

namespace BionicERP.Application.Crm.CustomerOrders.Commands {
    public class DeleteCustomerOrderCommandHandler : IRequestHandler<DeleteCustomerOrderCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteCustomerOrderCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteCustomerOrderCommand request, CancellationToken cancellationToken) {
            CustomerOrder customerOrder = await _database.CustomerOrder.FindAsync (request.Id);

            if (customerOrder == null) {
                throw new NotFoundException ("Customer Order", request.Id);
            }

            _database.CustomerOrder.Remove (customerOrder);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}