/*
 * @CreateTime: Aug 15, 2019 7:36 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 15, 2019 7:36 PM 
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Commands {
    public class UpdatePurchaseOrderPaymentCommandValidator : AbstractValidator<UpdatePurchaseOrderPaymentCommand> {
        public UpdatePurchaseOrderPaymentCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
            RuleFor (x => x.PurchaseOrderId).NotNull ();
            RuleFor (x => x.Amount).NotNull ();
            RuleFor (x => x.Date).NotNull ();
        }
    }
}