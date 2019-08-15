/*
 * @CreateTime: Aug 15, 2019 7:50 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 7:53 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Procurment.PurchaseOrderPayments.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Queries {
    public class GetPurchaseOrderPaymentByIdQueryHandler : IRequestHandler<GetPurchaseOrderPaymentByIdQuery, PurchaseOrderPaymentView> {
        private readonly IBionicERPDatabaseService _database;

        public GetPurchaseOrderPaymentByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<PurchaseOrderPaymentView> Handle (GetPurchaseOrderPaymentByIdQuery request, CancellationToken cancellationToken) {
            PurchaseOrderPaymentView payment = await _database.InvoicePayments
                .Select (PurchaseOrderPaymentView.Projection)
                .FirstOrDefaultAsync (p => p.Id == request.Id);

            if (payment == null) {
                throw new NotFoundException ("Payment", request.Id);
            }

            return payment;
        }
    }
}