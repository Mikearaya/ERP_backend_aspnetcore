/*
 * @CreateTime: Dec 24, 2018 9:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 9:06 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Procurment;
using BionicInventory.Application.Vendors.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Vendors.Queries.Single {
    public class GetVendorByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, VendorView> {
        private readonly IBionicERPDatabaseService _database;

        public GetVendorByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<VendorView> Handle (GetVendorByIdQuery request, CancellationToken cancellationToken) {

            var vendor = await _database.Vendor
                .Select (VendorView.Projection)
                .FirstOrDefaultAsync (v => v.id == request.Id);

            if (vendor == null) {
                throw new NotFoundException (nameof (Vendor), request.Id);
            }

            return vendor;
        }
    }
}