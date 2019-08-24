/*
 * @CreateTime: Aug 23, 2019 2:57 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:58 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Commands {
    public class DeleteUnitOfMeasurmentCommandValidator : AbstractValidator<DeleteUnitOfMeasurmentCommand> {
        public DeleteUnitOfMeasurmentCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
        }
    }
}