/*
 * @CreateTime: Aug 23, 2019 2:51 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 23, 2019 2:51 PM 
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Commands {
    public class UpdateUnitOfMeasurmentCommandValidator : AbstractValidator<UpdateUnitOfMeasurmentCommand> {
        public UpdateUnitOfMeasurmentCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
            RuleFor (x => x.Name).NotEmpty ().NotNull ();
            RuleFor (x => x.Abrivation).NotNull ().NotEmpty ();
            RuleFor (x => x.Active).NotNull ();
        }
    }
}