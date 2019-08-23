using FluentValidation;

namespace BionicERP.Application.Inventory.ProductGroups.Commands {
    public class UpdateProductGroupCommandValidator : AbstractValidator<UpdateProductGroupCommand> {
        public UpdateProductGroupCommandValidator () {
            RuleFor (x => x.GroupName).NotNull ().NotEmpty ();
            RuleFor (x => x.Id).NotNull ();
        }
    }
}