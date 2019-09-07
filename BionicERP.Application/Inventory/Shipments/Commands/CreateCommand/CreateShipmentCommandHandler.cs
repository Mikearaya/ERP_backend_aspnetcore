/*
 * @CreateTime: Sep 7, 2019 3:51 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 7, 2019 3:51 PM 
 * @Description: Modify Here, Please  
 */
/*
 * @CreateTime: Sep 7, 2019 3:47 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 3:51 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.Shipments.Models;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.Shipments.Commands {
    public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public CreateShipmentCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateShipmentCommand, Shipment> ();
                x.CreateMap<ShipmentItem, ShipmentDetail> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreateShipmentCommand request, CancellationToken cancellationToken) {
            Shipment newShipment = _Mapper.Map<CreateShipmentCommand, Shipment> (request);

            await _database.Shipment.AddAsync (newShipment);

            await _database.SaveAsync ();

            return newShipment.Id;
        }
    }
}