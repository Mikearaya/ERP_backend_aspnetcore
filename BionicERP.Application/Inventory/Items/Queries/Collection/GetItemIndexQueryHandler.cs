using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.Items.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
/*
 * @CreateTime: Aug 5, 2019 9:08 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:12 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Inventory.Items.Queries {
    public class GetItemIndexQueryHandler : IRequestHandler<GetItemIndexQuery, IEnumerable<ItemIndexModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetItemIndexQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<ItemIndexModel>> Handle (GetItemIndexQuery request, CancellationToken cancellationToken) {
            var itemIndex = _database.Item
                .Where (i =>
                    i.Code.Contains (request.SearchString) ||
                    i.Name.Contains (request.SearchString));

            if (request.VendorId != 0) {
                itemIndex = itemIndex.Where (i => i.VendorPurchaseTerm.Any (v => v.VendorId == request.VendorId));
            }

            return await itemIndex.Select (ItemIndexModel.Projection).ToListAsync ();
        }
    }
}