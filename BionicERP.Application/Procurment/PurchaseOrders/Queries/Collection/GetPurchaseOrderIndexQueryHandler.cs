/*
 * @CreateTime: Aug 17, 2019 11:09 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 17, 2019 11:23 AM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Procurment.PurchaseOrders.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrders.Queries {
    public class GetPurchaseOrderIndexQueryHandler : IRequestHandler<GetPurchaseOrderIndexQuery, IEnumerable<PurchaseOrderIndexModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetPurchaseOrderIndexQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public Task<IEnumerable<PurchaseOrderIndexModel>> Handle (GetPurchaseOrderIndexQuery request, CancellationToken cancellationToken) {

            IEnumerable<PurchaseOrderIndexModel> purchaseOrder;

            if (request.Type.ToUpper () == "ALL") {
                purchaseOrder = _database.PurchaseOrder
                    .Select (PurchaseOrderIndexModel.Projection);

            } else {
                purchaseOrder = _database.PurchaseOrder
                    .Select (PurchaseOrderIndexModel.Balance)
                    .Where (p => p.RemainingAmount > 0);

            }

            if (request.Id != 0) {
                purchaseOrder = purchaseOrder.Where (p => p.Id == request.Id);
            }

            return Task.FromResult<IEnumerable<PurchaseOrderIndexModel>> (purchaseOrder.ToList ());
        }
    }
}