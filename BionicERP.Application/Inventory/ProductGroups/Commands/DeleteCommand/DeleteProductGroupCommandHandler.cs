/*
 * @CreateTime: Aug 23, 2019 2:11 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:13 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.ProductGroups.Commands {
    public class DeleteProductGroupCommandHandler : IRequestHandler<DeleteProductGroupCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteProductGroupCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteProductGroupCommand request, CancellationToken cancellationToken) {
            ProductGroup productGroup = await _database.ProductGroup.FindAsync (request.Id);

            if (productGroup == null) {
                throw new NotFoundException ("Product Group", request.Id);
            }

            _database.ProductGroup.Remove (productGroup);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}