/*
 * @CreateTime: Aug 5, 2019 9:37 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:39 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Procurment.PurchaseTerms.Commands {
    public class CreatePurchaseTermCommandValidator : AbstractValidator<CreatePurchaseTermCommand> {
        public CreatePurchaseTermCommandValidator () {
            RuleFor (x => x.ItemId).NotNull ().NotEmpty ();
            RuleFor (x => x.VendorId).NotNull ().NotEmpty ();
            RuleFor (x => x.UnitPrice).NotNull ().NotEmpty ();
            RuleFor (x => x.MinimumQuantity).NotNull ().NotEmpty ();
        }
    }
}