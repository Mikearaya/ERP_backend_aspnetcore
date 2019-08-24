/*
 * @CreateTime: Aug 24, 2019 10:30 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 10:34 AM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.UnitOfMeasurments.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Queries {
    public class GetUnitOfMeasurmentByIdQueryHandler : IRequestHandler<GetUnitOfMeasurmentByIdQuery, UnitOfMeasurmentViewModel> {
        private readonly IBionicERPDatabaseService _database;

        public GetUnitOfMeasurmentByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<UnitOfMeasurmentViewModel> Handle (GetUnitOfMeasurmentByIdQuery request, CancellationToken cancellationToken) {
            UnitOfMeasurmentViewModel uom = await _database.UnitsOfMeasurment
                .Select (UnitOfMeasurmentViewModel.Projection)
                .FirstOrDefaultAsync (u => u.Id == request.Id);

            if (uom == null) {
                throw new NotFoundException ("Unit of Measurment", request.Id);
            }

            return uom;
        }
    }
}