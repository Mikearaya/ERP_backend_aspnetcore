using System.Collections.Generic;
/*
 * @CreateTime: Sep 10, 2019 12:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:08 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Interfaces;
using BionicERP.Application.SystemLookups.Models;
using BionicERP.Domain;
using MediatR;

namespace BionicERP.Application.SystemLookups.Commands {
    public class CreateSystemLookupCommandHandler : IRequestHandler<CreateSystemLookupCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;

        public CreateSystemLookupCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<NewSystemLookupModel, SystemLookup> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (CreateSystemLookupCommand request, CancellationToken cancellationToken) {
            IEnumerable<SystemLookup> lookup = _Mapper.Map<IEnumerable<NewSystemLookupModel>, IEnumerable<SystemLookup>> (request.Lookups);

            await _database.SystemLookups.AddRangeAsync (lookup);
            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}