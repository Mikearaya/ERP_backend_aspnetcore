/*
 * @CreateTime: Aug 5, 2019 9:49 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:52 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Procurment;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseTerms.Commands {
    public class DeletePurchaseTermCommandHandler : IRequestHandler<DeletePurchaseTermCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeletePurchaseTermCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeletePurchaseTermCommand request, CancellationToken cancellationToken) {
            var term = await _database.VendorPurchaseTerm.FindAsync (request.Id);

            if (term == null) {
                throw new NotFoundException (nameof (VendorPurchaseTerm), request.Id);
            }

            _database.VendorPurchaseTerm.Remove (term);

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}