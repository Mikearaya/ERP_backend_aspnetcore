/*
 * @CreateTime: Aug 15, 2019 7:23 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 8:01 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Commands {
    public class CreatePurchaseOrderPaymentCommandValidator : AbstractValidator<CreatePurchaseOrderPaymentCommand> {
        public CreatePurchaseOrderPaymentCommandValidator () {
            RuleFor (x => x.PurchaseOrderId).NotNull ();
            RuleFor (x => x.Amount).NotNull ();
            RuleFor (x => x.Date).NotNull ();

        }
    }
}