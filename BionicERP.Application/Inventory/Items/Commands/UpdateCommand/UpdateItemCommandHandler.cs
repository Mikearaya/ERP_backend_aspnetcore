/*
 * @CreateTime: Aug 5, 2019 8:51 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 8:53 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.Items.Commands {
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public UpdateItemCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateItemCommand, Item> ();
            }).CreateMapper ();

        }

        public async Task<Unit> Handle (UpdateItemCommand request, CancellationToken cancellationToken) {
            var item = await _database.Item.FindAsync (request.Id);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.Id);
            }

            _Mapper.Map (request, item);

            _database.Item.Update (item);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}