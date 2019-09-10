/*
 * @CreateTime: Sep 10, 2019 12:32 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:34 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.SystemLookups.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.SystemLookups.Queries {
    public class GetSystemLookupByIdQueryHandler : IRequestHandler<GetSystemLookupByIdQuery, SystemLookupViewModel> {
        private readonly IBionicERPDatabaseService _database;

        public GetSystemLookupByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<SystemLookupViewModel> Handle (GetSystemLookupByIdQuery request, CancellationToken cancellationToken) {
            SystemLookupViewModel lookup = await _database.SystemLookups
                .Select (SystemLookupViewModel.Projection)
                .FirstOrDefaultAsync (s => s.Id == request.Id);

            if (lookup == null) {
                throw new NotFoundException ("System lookup", request.Id);
            }

            return lookup;
        }
    }
}