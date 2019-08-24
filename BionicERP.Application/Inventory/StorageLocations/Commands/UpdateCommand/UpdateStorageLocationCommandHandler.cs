/*
 * @CreateTime: Aug 24, 2019 10:56 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 11:00 AM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.StorageLocations.Commands {
    public class UpdateStorageLocationCommandHandler : IRequestHandler<UpdateStorageLocationCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public UpdateStorageLocationCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateStorageLocationCommand, StorageLocation> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateStorageLocationCommand request, CancellationToken cancellationToken) {

            StorageLocation storage = await _database.StorageLocation.FindAsync (request.Id);

            if (storage == null) {
                throw new NotFoundException ("Storage Location", request.Id);
            }

            _Mapper.Map (request, storage);
            _database.StorageLocation.Update (storage);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}