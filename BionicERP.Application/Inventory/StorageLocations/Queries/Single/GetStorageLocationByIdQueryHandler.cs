/*
 * @CreateTime: Aug 24, 2019 11:13 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 11:17 AM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.StorageLocations.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.StorageLocations.Queries {
    public class GetStorageLocationByIdQueryHandler : IRequestHandler<GetStorageLocationByIdQuery, StorageLocationViewModel> {
        private readonly IBionicERPDatabaseService _database;

        public GetStorageLocationByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<StorageLocationViewModel> Handle (GetStorageLocationByIdQuery request, CancellationToken cancellationToken) {
            StorageLocationViewModel storage = await _database.StorageLocation
                .Select (StorageLocationViewModel.Projection)
                .FirstOrDefaultAsync (s => s.Id == request.Id);

            if (storage == null) {
                throw new NotFoundException ("Storage Location", request.Id);
            }

            return storage;
        }
    }
}