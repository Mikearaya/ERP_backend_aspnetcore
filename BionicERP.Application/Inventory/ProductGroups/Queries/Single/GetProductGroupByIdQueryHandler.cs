/*
 * @CreateTime: Aug 23, 2019 2:28 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:32 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.ProductGroups.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.ProductGroups.Queries {
    public class GetProductGroupByIdQueryHandler : IRequestHandler<GetProductGroupByIdQuery, ProductGroupViewModel> {
        private readonly IBionicERPDatabaseService _database;

        public GetProductGroupByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<ProductGroupViewModel> Handle (GetProductGroupByIdQuery request, CancellationToken cancellationToken) {
            ProductGroupViewModel groupView = await _database.ProductGroup
                .Select (ProductGroupViewModel.Projection)
                .FirstOrDefaultAsync (p => p.Id == request.Id);

            if (groupView == null) {
                throw new NotFoundException ("Product Group", request.Id);
            }

            return groupView;
        }
    }
}