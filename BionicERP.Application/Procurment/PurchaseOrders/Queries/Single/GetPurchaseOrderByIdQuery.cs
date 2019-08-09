/*
 * @CreateTime: Aug 9, 2019 2:11 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 2:13 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Procurment.PurchaseOrders.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrders.Queries {
    public class GetPurchaseOrderByIdQuery : IRequest<PurchaseOrderDetailView> {
        public uint Id { get; set; }

    }
}