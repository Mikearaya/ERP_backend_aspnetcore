/*
 * @CreateTime: Aug 5, 2019 8:46 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 8:48 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.Items.Commands {
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand> {
        public CreateItemCommandValidator () {
            RuleFor (x => x.Name).NotNull ().NotEmpty ();
            RuleFor (x => x.Code).NotEmpty ().NotNull ();
            RuleFor (x => x.DefaultStorageId).NotNull ().NotEmpty ();
            RuleFor (x => x.PrimaryUomId).NotNull ().NotEmpty ();
            RuleFor (x => x.Price).NotNull ().NotNull ();

        }
    }
}