using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.UnitOfMeasurments.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
/*
 * @CreateTime: Aug 23, 2019 3:08 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 3:11 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Inventory.UnitOfMeasurments.Queries {
    public class GetUnitOfMeasurmentIndexQueryHandler : IRequestHandler<GetUnitOfMeasurmentIndexQuery, IEnumerable<UnitOfMeasurmentIndexModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetUnitOfMeasurmentIndexQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<UnitOfMeasurmentIndexModel>> Handle (GetUnitOfMeasurmentIndexQuery request, CancellationToken cancellationToken) {
            IEnumerable<UnitOfMeasurmentIndexModel> unitOfMeasurmentIndex = await _database.UnitsOfMeasurment
                .Select (UnitOfMeasurmentIndexModel.Projection)
                .Where (p => p.Name.ToUpper ().Contains (request.Name.ToUpper ()))
                .ToListAsync ();

            return unitOfMeasurmentIndex;
        }
    }
}