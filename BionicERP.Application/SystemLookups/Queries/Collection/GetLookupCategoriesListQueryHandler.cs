/*
 * @CreateTime: May 12, 2019 2:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:43 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.SystemLookups.Models;
using BionicERP.Commons.QueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.SystemLookups.Queries {
    public class GetSystemLookupCategoriesListQueryHandler : ApiQueryString, IRequestHandler<GetSystemLookupCategoriesListQuery, IEnumerable<SystemLookupCategoryIndexModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetSystemLookupCategoriesListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<SystemLookupCategoryIndexModel>> Handle (GetSystemLookupCategoriesListQuery request, CancellationToken cancellationToken) {
            return await _database.SystemLookups
                .Where (l => l.Type.ToLower () == "system_lookup")
                .Select (SystemLookupCategoryIndexModel.Project)
                .ToListAsync ();
        }
    }
}