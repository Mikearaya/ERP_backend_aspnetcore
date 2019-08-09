/*
 * @CreateTime: Aug 5, 2019 10:00 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 10:03 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Procurment.PurchaseTerms.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Procurment.PurchaseTerms.Queries {
    public class GetPurchaseTermByIdQueryHandler : IRequestHandler<GetPurchaseTermByIdQuery, PurchaseTermViewModel> {
        private readonly IBionicERPDatabaseService _database;

        public GetPurchaseTermByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<PurchaseTermViewModel> Handle (GetPurchaseTermByIdQuery request, CancellationToken cancellationToken) {
            PurchaseTermViewModel purchaseTerm = await _database.VendorPurchaseTerm
                .Select (PurchaseTermViewModel.Projection)
                .FirstOrDefaultAsync (v => v.Id == request.Id);

            if (purchaseTerm == null) {
                throw new NotFoundException ("Purchase Term", request.Id);
            }
            return purchaseTerm;
        }
    }
}