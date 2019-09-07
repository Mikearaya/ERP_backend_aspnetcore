/*
 * @CreateTime: Sep 7, 2019 1:36 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 7, 2019 1:36 PM 
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.WriteOffs.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.WriteOffs.Queries {
    public class GetWriteOffByIdQueryHandler : IRequestHandler<GetWriteOffByIdQuery, WriteOffDetailViewModel> {
        private readonly IBionicERPDatabaseService _database;

        public GetWriteOffByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<WriteOffDetailViewModel> Handle (GetWriteOffByIdQuery request, CancellationToken cancellationToken) {
            WriteOffDetailViewModel writeOff = await _database.WriteOff
                .Where (w => w.Id == request.Id)
                .Select (WriteOffDetailViewModel.Projection)
                .FirstOrDefaultAsync ();

            if (writeOff == null) {
                throw new NotFoundException ("Write Off", request.Id);
            }

            return writeOff;
        }
    }
}