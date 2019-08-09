/*
 * @CreateTime: Aug 5, 2019 9:59 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 10:00 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Procurment.PurchaseTerms.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseTerms.Queries {
    public class GetPurchaseTermByIdQuery : IRequest<PurchaseTermViewModel> {
        public uint Id { get; set; }

    }
}