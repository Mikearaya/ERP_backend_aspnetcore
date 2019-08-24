/*
 * @CreateTime: Aug 24, 2019 11:04 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 11:05 AM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.StorageLocations.Commands {
    public class DeleteStorageLocationCommandValidator : AbstractValidator<DeleteStorageLocationCommand> {
        public DeleteStorageLocationCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
        }
    }
}