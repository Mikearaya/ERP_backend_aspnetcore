/*
 * @CreateTime: Aug 24, 2019 10:50 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 10:54 AM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.StorageLocations.Commands {
    public class CreateStorageLocationCommandHandler : IRequestHandler<CreateStorageLocationCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public CreateStorageLocationCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateStorageLocationCommand, StorageLocation> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreateStorageLocationCommand request, CancellationToken cancellationToken) {

            StorageLocation newStorage = _Mapper.Map<CreateStorageLocationCommand, StorageLocation> (request);

            await _database.StorageLocation.AddAsync (newStorage);
            await _database.SaveAsync ();

            return newStorage.Id;

        }
    }
}