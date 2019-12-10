/*
 * @CreateTime: Dec 10, 2019 3:57 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 10, 2019 4:00 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Procurment.Vendors.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Procurment.Vendors.Queries {
    public class GetVendorPurchaseTermQueryHandler : IRequestHandler<GetVendorPurchaseTermQuery, IEnumerable<VendorPurchaseTermView>> {
        private readonly IBionicERPDatabaseService _database;

        public GetVendorPurchaseTermQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<VendorPurchaseTermView>> Handle (GetVendorPurchaseTermQuery request, CancellationToken cancellationToken) {
            IEnumerable<VendorPurchaseTermView> purchaseTerms = await _database.VendorPurchaseTerm
                .Where (v => v.VendorId == request.VendorId)
                .Select (VendorPurchaseTermView.Projection)
                .ToListAsync ();

            return purchaseTerms;
        }
    }
}