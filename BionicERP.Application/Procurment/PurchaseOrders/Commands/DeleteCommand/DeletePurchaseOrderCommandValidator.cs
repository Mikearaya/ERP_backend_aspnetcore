/*
 * @CreateTime: Aug 9, 2019 2:01 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 2:02 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Procurment.PurchaseOrders.Commands {
    public class DeletePurchaseOrderCommandValidator : AbstractValidator<DeletePurchaseOrderCommand> {
        public DeletePurchaseOrderCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
        }
    }
}