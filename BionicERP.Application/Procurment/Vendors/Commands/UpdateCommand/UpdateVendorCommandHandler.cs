/*
 * @CreateTime: Dec 23, 2018 11:15 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:10 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Procurment;
using MediatR;

namespace BionicERP.Application.Procurment.Vendors.Commands {
    public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public UpdateVendorCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateVendorCommand, Vendor> ();
            }).CreateMapper ();

        }

        public async Task<Unit> Handle (UpdateVendorCommand request, CancellationToken cancellationToken) {
            Vendor vendor = await _database.Vendor.FindAsync (request.Id);

            if (vendor == null) {
                throw new NotFoundException (nameof (Vendor), request.Id);
            }
            _Mapper.Map (request, vendor);

            _database.Vendor.Update (vendor);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}