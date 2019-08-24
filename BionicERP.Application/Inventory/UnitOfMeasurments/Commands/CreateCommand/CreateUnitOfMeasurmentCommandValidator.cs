/*
 * @CreateTime: Aug 23, 2019 2:44 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:46 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Commands {
    public class CreateUnitOfMeasurmentCommandValidator : AbstractValidator<CreateUnitOfMeasurmentCommand> {
        public CreateUnitOfMeasurmentCommandValidator () {
            RuleFor (x => x.Name).NotNull ();
            RuleFor (x => x.Abrivation).NotNull ().NotEmpty ();
            RuleFor (x => x.Active).NotNull ();
        }
    }
}