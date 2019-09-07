/*
 * @CreateTime: Sep 7, 2019 3:54 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 3:59 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.Shipments.Models;
using BionicERP.Domain.Inventory;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.Shipments.Commands {
    public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public UpdateShipmentCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateShipmentCommand, Shipment> ();
                x.CreateMap<ShipmentItem, ShipmentDetail> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateShipmentCommand request, CancellationToken cancellationToken) {
            Shipment shipment = await _database.Shipment
                .Include (x => x.ShipmentDetail)
                .FirstOrDefaultAsync (s => s.Id == request.Id);

            if (shipment == null) {
                throw new NotFoundException ("Shipment", request.Id);
            }

            _Mapper.Map (request, shipment);
            _database.Shipment.Update (shipment);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}