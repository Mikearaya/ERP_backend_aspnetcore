/*
 * @CreateTime: Aug 9, 2019 2:21 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 9, 2019 2:21 PM 
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrders.Commands {
    public class UpdatePurchaseOrderCommandHandler : IRequestHandler<UpdatePurchaseOrderCommand, Unit> {
        public Task<Unit> Handle (UpdatePurchaseOrderCommand request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException ();
        }
    }
}