using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Procurment.Vendors.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
/*
 * @CreateTime: Aug 5, 2019 2:17 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:21 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Procurment.Vendors.Queries {
    public class GetVendorIndexQueryHandler : IRequestHandler<GetVendorIndexQuery, IEnumerable<VendorIndexModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetVendorIndexQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<VendorIndexModel>> Handle (GetVendorIndexQuery request, CancellationToken cancellationToken) {
            IEnumerable<VendorIndexModel> vendorsIndex = await _database.Vendor
                .Select (VendorIndexModel.Projection)
                .Where (v => v.Name.ToUpper ().StartsWith (request.Name.ToUpper ()))
                .ToListAsync ();

            return vendorsIndex;
        }
    }
}