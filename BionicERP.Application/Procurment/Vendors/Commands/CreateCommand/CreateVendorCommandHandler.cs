/*
 * @CreateTime: Dec 23, 2018 11:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:41 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Procurment;
using MediatR;

namespace BionicERP.Application.Procurment.Vendors.Commands {
    public class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;

        public CreateVendorCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateVendorCommand, Vendor> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreateVendorCommand request, CancellationToken cancellationToken) {

            Vendor vendor = _Mapper.Map<CreateVendorCommand, Vendor> (request);

            await _database.Vendor.AddAsync (vendor);
            await _database.SaveAsync ();

            return vendor.Id;

        }
    }
}