/*
 * @CreateTime: Aug 15, 2019 7:49 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 7:50 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Procurment.PurchaseOrderPayments.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Queries {
    public class GetPurchaseOrderPaymentByIdQuery : IRequest<PurchaseOrderPaymentView> {
        public uint Id { get; set; }
    }
}