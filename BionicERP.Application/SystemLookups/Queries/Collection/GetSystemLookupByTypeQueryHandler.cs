/*
 * @CreateTime: May 6, 2019 11:47 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:44 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.SystemLookups.Models;
using BionicERP.Commons.QueryHelpers;
using MediatR;

namespace BionicERP.Application.SystemLookups.Queries {
    public class GetSystemLookupByTypeQueryHandler : IRequestHandler<GetSystemLookupByTypeQuery, IEnumerable<SystemLookupIndexModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetSystemLookupByTypeQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<SystemLookupIndexModel>> Handle (GetSystemLookupByTypeQuery request, CancellationToken cancellationToken) {
            var lookup = _database.SystemLookups
                .Where (c => c.Type.Trim ().ToLower ().Equals (request.Type.Trim ().ToLower ()) &&
                    c.Value.Trim ().ToLower ().StartsWith (request.SearchString.ToLower ().Trim ()))
                .Select (SystemLookupIndexModel.Projection)
                .Select (DynamicQueryHelper.GenerateSelectedColumns<SystemLookupIndexModel> (request.SelectedColumns))
                .Skip (request.PageNumber * request.PageSize)
                .Take (request.PageSize)
                .ToList ();

            return Task.FromResult<IEnumerable<SystemLookupIndexModel>> (lookup);
        }
    }
}