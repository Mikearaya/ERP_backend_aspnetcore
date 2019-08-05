/*
 * @CreateTime: Dec 23, 2018 11:22 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:06 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Procurment;
using MediatR;

namespace BionicERP.Application.Procurment.Vendors.Commands {
    public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteVendorCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteVendorCommand request, CancellationToken cancellationToken) {
            var vendor = await _database.Vendor.FindAsync (request.Id);

            if (vendor == null) {
                throw new NotFoundException (nameof (Vendor), request.Id);
            }

            _database.Vendor.Remove (vendor);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}