/*
 * @CreateTime: Sep 10, 2019 12:11 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:14 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Interfaces;
using BionicERP.Application.SystemLookups.Models;
using BionicERP.Domain;
using MediatR;

namespace BionicERP.Application.SystemLookups.Commands {
    public class UpdateSystemLookupCommandHandler : IRequestHandler<UpdateSystemLookupCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;

        public UpdateSystemLookupCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<NewSystemLookupModel, SystemLookup> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateSystemLookupCommand request, CancellationToken cancellationToken) {
            var lookups = _Mapper.Map<IEnumerable<NewSystemLookupModel>, IEnumerable<SystemLookup>> (request.Lookups);

            _database.SystemLookups.UpdateRange (lookups);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}