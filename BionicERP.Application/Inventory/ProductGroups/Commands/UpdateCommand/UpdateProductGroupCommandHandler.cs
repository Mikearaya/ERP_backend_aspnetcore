/*
 * @CreateTime: Aug 23, 2019 2:03 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:09 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.ProductGroups.Commands {
    public class UpdateProductGroupCommandHandler : IRequestHandler<UpdateProductGroupCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public UpdateProductGroupCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateProductGroupCommand, ProductGroup> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateProductGroupCommand request, CancellationToken cancellationToken) {

            ProductGroup productGroup = await _database.ProductGroup.FindAsync (request.Id);

            if (productGroup == null) {
                throw new NotFoundException ("Product Group", request.Id);
            }

            _Mapper.Map (request, productGroup);

            _database.ProductGroup.Update (productGroup);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}