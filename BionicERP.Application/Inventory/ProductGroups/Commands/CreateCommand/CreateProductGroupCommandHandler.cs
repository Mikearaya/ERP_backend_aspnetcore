/*
 * @CreateTime: Aug 23, 2019 1:57 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:01 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.ProductGroups.Commands {
    public class CreateProductGroupCommandHandler : IRequestHandler<CreateProductGroupCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public CreateProductGroupCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateProductGroupCommand, ProductGroup> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreateProductGroupCommand request, CancellationToken cancellationToken) {
            ProductGroup newGroup = _Mapper.Map<CreateProductGroupCommand, ProductGroup> (request);

            await _database.ProductGroup.AddAsync (newGroup);
            await _database.SaveAsync ();

            return newGroup.Id;
        }
    }
}