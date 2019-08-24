/*
 * @CreateTime: Aug 23, 2019 2:52 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:56 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Commands {
    public class UpdateUnitOfMeasurmentCommandHandler : IRequestHandler<UpdateUnitOfMeasurmentCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;

        public UpdateUnitOfMeasurmentCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateUnitOfMeasurmentCommand, UnitOfMeasurment> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateUnitOfMeasurmentCommand request, CancellationToken cancellationToken) {

            UnitOfMeasurment uom = await _database.UnitsOfMeasurment.FindAsync (request.Id);

            if (uom == null) {
                throw new NotFoundException ("UOM", request.Id);
            }

            _Mapper.Map (request, uom);
            _database.UnitsOfMeasurment.Update (uom);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}