/*
 * @CreateTime: Sep 7, 2019 1:10 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:12 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.WriteOffs.Commands {
    public class UpdateWriteOffCommandValidator : AbstractValidator<UpdateWriteOffCommand> {
        public UpdateWriteOffCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
            RuleFor (x => x.Type).NotNull ();
            RuleFor (x => x.Status).NotNull ();
            RuleForEach (x => x.WriteOffDetail).SetValidator (new WriteOffDetailValidator ());
        }

    }

}