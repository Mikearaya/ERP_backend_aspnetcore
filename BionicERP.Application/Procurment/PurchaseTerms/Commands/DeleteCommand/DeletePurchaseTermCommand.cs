/*
 * @CreateTime: Aug 5, 2019 9:49 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:50 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseTerms.Commands {
    public class DeletePurchaseTermCommand : IRequest {
        public uint Id { get; set; }
    }
}