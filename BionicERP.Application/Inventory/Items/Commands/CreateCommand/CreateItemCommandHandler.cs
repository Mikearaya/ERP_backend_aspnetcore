/*
 * @CreateTime: Aug 5, 2019 8:42 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 8:46 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.Items.Commands {
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;

        public CreateItemCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateItemCommand, Item> ();
            }).CreateMapper ();

        }

        public async Task<uint> Handle (CreateItemCommand request, CancellationToken cancellationToken) {

            var itemCodeUnique = await _database.Item
                .AnyAsync (i => i.Code.Trim ().ToUpper () == request.Code.Trim ().ToUpper ());

            if (itemCodeUnique) {
                throw new DuplicateKeyException ("Item code", request.Code);
            }

            Item newItem = _Mapper.Map<CreateItemCommand, Item> (request);

            _database.Item.Add (newItem);
            await _database.SaveAsync ();

            return newItem.Id;
        }
    }
}