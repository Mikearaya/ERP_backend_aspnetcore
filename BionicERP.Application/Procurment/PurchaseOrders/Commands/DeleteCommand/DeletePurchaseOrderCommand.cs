/*
 * @CreateTime: Aug 9, 2019 2:01 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 2:03 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrders.Commands {
    public class DeletePurchaseOrderCommand : IRequest {
        public uint Id { get; set; }
    }
}