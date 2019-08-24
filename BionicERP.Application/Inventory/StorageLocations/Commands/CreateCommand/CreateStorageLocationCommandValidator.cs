/*
 * @CreateTime: Aug 24, 2019 10:54 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 10:55 AM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.StorageLocations.Commands {
    public class CreateStorageLocationCommandValidator : AbstractValidator<CreateStorageLocationCommand> {
        public CreateStorageLocationCommandValidator () {
            RuleFor (x => x.Name).NotEmpty ().NotNull ();
            RuleFor (x => x.Active).NotNull ();
        }
    }
}