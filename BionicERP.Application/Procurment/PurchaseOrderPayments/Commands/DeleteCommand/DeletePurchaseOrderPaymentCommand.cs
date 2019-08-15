/*
 * @CreateTime: Aug 15, 2019 7:40 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 8:02 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Commands {
    public class DeletePurchaseOrderPaymentCommand : IRequest {
        public uint Id { get; set; }
    }
}