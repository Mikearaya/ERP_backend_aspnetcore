/*
 * @CreateTime: Aug 5, 2019 9:44 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:45 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Procurment.PurchaseTerms.Commands {
    public class UpdatePurchaseTermCommandValidator : AbstractValidator<UpdatePurchaseTermCommand> {
        public UpdatePurchaseTermCommandValidator () {
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
            RuleFor (x => x.ItemId).NotNull ().NotEmpty ();
            RuleFor (x => x.VendorId).NotNull ().NotEmpty ();
            RuleFor (x => x.UnitPrice).NotNull ().NotEmpty ();
            RuleFor (x => x.MinimumQuantity).NotNull ().NotEmpty ();
        }
    }
}