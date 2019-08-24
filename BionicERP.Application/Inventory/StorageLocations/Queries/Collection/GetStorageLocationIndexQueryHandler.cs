using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.StorageLocations.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
/*
 * @CreateTime: Aug 24, 2019 11:06 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 11:08 AM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Inventory.StorageLocations.Queries {
    public class GetStorageLocationIndexQueryHandler : IRequestHandler<GetStorageLocationIndexQuery, IEnumerable<StorageLocationIndexModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetStorageLocationIndexQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<StorageLocationIndexModel>> Handle (GetStorageLocationIndexQuery request, CancellationToken cancellationToken) {
            IEnumerable<StorageLocationIndexModel> storageIndex = await _database.StorageLocation
                .Select (StorageLocationIndexModel.Projection)
                .Where (p => p.Name.ToUpper ().Contains (request.Name.ToUpper ()))
                .ToListAsync ();

            return storageIndex;
        }
    }
}