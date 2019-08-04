/*
 * @CreateTime: Dec 23, 2018 11:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 9:04 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicInventory.Application.Vendors.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.Application.Vendors.Queries.Collections {
    public class GetVendorsListViewQueryHandler : IRequestHandler<GetVendorsListQuery, IEnumerable<VendorView>> {
        private IBionicERPDatabaseService _database;

        public GetVendorsListViewQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<VendorView>> Handle (GetVendorsListQuery request, CancellationToken cancellationToken) {
            return await _database.Vendor
                .Select (VendorView.Projection)
                .ToListAsync ();
        }
    }
}