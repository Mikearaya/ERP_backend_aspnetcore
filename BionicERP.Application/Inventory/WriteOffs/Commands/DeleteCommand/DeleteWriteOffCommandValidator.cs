/*
 * @CreateTime: Sep 7, 2019 1:20 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 7, 2019 1:20 PM 
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.WriteOffs.Commands {
    public class DeleteWriteOffCommandValidator : AbstractValidator<DeleteWriteOffCommand> {
        public DeleteWriteOffCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
        }
    }
}