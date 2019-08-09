/*
 * @CreateTime: Aug 9, 2019 1:48 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 1:54 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using FluentValidation;

namespace BionicERP.Application.Procurment.PurchaseOrders.Commands {
    public class CreatePurchaseOrderCommandValidator : AbstractValidator<CreatePurchaseOrderCommand> {
        public CreatePurchaseOrderCommandValidator () {
            RuleFor (x => x.PurchaseOrderItems.Count ()).NotEqual (0);
            RuleFor (x => x.VendorId).NotNull ();
            RuleFor (x => x.ExpectedDate).NotNull ();
            RuleForEach (x => x.PurchaseOrderItems).SetValidator (new PurchaseOrderItemValidator ());

        }
    }

    public class PurchaseOrderItemValidator : AbstractValidator<PurchaseOrderItem> {
        public PurchaseOrderItemValidator () {
            RuleFor (x => x.ItemId).NotNull ();
            RuleFor (x => x.Quantity).NotNull ().NotEqual (0);
        }
    }
}