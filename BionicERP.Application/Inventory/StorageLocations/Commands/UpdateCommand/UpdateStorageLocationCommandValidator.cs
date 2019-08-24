/*
 * @CreateTime: Aug 24, 2019 11:00 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 11:01 AM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.StorageLocations.Commands {
    public class UpdateStorageLocationCommandValidator : AbstractValidator<UpdateStorageLocationCommand> {
        public UpdateStorageLocationCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
            RuleFor (x => x.Name).NotEmpty ().NotNull ();
            RuleFor (x => x.Active).NotNull ();
        }
    }
}