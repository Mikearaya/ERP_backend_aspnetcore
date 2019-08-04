/*
 * @CreateTime: Dec 23, 2018 11:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 9:03 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Procurment;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Vendors.Commands.Update {
    public class UpdateVendorCommandHandler : IRequestHandler<UpdatedVendorDto, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public UpdateVendorCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdatedVendorDto request, CancellationToken cancellationToken) {
            var vendor = await _database.Vendor.FindAsync (request.Id);

            if (vendor == null) {
                throw new NotFoundException (nameof (Vendor), request.Id);
            }

            if (vendor.TinNumber.ToUpper () != request.TinNumber.ToUpper () && request.TinNumber.Length > 0) {
                var tin = await _database.Vendor
                    .Where (v => v.TinNumber.ToUpper () == request.TinNumber.ToUpper ())
                    .CountAsync ();

                if (tin > 0) {
                    throw new DuplicateTinNumberException (request.TinNumber);
                }
            }

            vendor.Name = request.Name;
            vendor.PhoneNumber = request.PhoneNumber;
            vendor.PaymentPeriod = request.PaymentPeriod;
            vendor.LeadTime = request.LeadTime;
            vendor.TinNumber = request.TinNumber;

            _database.Vendor.Update (vendor);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}