using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Users.Models;
/*
 * @CreateTime: Sep 10, 2019 9:16 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:18 AM
 * @Description: Modify Here, Please  
 */
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Users.Queries {
    public class GetUserIndexQueryHandler : IRequestHandler<GetUserIndexQuery, IEnumerable<UserIndexModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetUserIndexQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<UserIndexModel>> Handle (GetUserIndexQuery request, CancellationToken cancellationToken) {
            return await _database.Users
                .Where (u => u.NormalizedUserName.StartsWith (request.SearchString.Trim ().ToUpper ()))
                .Select (UserIndexModel.Projection)
                .ToListAsync ();
        }
    }
}