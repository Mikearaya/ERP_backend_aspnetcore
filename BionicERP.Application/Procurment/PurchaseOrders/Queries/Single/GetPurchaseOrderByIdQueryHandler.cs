/*
 * @CreateTime: Aug 9, 2019 2:12 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 2:14 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Procurment.PurchaseOrders.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Procurment.PurchaseOrders.Queries {
    public class GetPurchaseOrderByIdQueryHandler : IRequestHandler<GetPurchaseOrderByIdQuery, PurchaseOrderDetailView> {
        private readonly IBionicERPDatabaseService _database;

        public GetPurchaseOrderByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<PurchaseOrderDetailView> Handle (GetPurchaseOrderByIdQuery request, CancellationToken cancellationToken) {
            return _database.PurchaseOrder
                .Include (p => p.PurchaseOrderQuotation)
                .Include (p => p.StockBatch)
                .Where (po => po.Id == request.Id)
                .Select (PurchaseOrderDetailView.Projection)
                .FirstOrDefaultAsync ();
        }
    }
}