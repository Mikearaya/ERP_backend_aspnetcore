/*
 * @CreateTime: Aug 15, 2019 7:41 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 8:02 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Commands {
    public class DeletePurchaseOrderPaymentCommandValidator : AbstractValidator<DeletePurchaseOrderPaymentCommand> {
        public DeletePurchaseOrderPaymentCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
        }
    }
}