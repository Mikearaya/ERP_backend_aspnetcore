/*
 * @CreateTime: Aug 23, 2019 2:43 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 23, 2019 2:43 PM 
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Commands {
    public class CreateUnitOfMeasurmentCommandHandler : IRequestHandler<CreateUnitOfMeasurmentCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public CreateUnitOfMeasurmentCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateUnitOfMeasurmentCommand, UnitOfMeasurment> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreateUnitOfMeasurmentCommand request, CancellationToken cancellationToken) {

            UnitOfMeasurment newUom = _Mapper.Map<CreateUnitOfMeasurmentCommand, UnitOfMeasurment> (request);

            await _database.UnitsOfMeasurment.AddAsync (newUom);
            await _database.SaveAsync ();

            return newUom.Id;
        }
    }
}