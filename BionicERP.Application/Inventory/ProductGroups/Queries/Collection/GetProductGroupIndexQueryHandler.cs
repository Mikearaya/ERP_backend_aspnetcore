using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.ProductGroups.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
/*
 * @CreateTime: Aug 23, 2019 2:24 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:32 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Inventory.ProductGroups.Queries {
    public class GetProductGroupIndexQueryHandler : IRequestHandler<GetProductGroupIndexQuery, IEnumerable<ProductGroupIndexModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetProductGroupIndexQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<ProductGroupIndexModel>> Handle (GetProductGroupIndexQuery request, CancellationToken cancellationToken) {
            IEnumerable<ProductGroupIndexModel> groupIndex = await _database.ProductGroup
                .Select (ProductGroupIndexModel.Projection)
                .Where (p => p.Name.ToUpper ().Contains (request.Name.ToUpper ()))
                .ToListAsync ();

            return groupIndex;
        }
    }
}