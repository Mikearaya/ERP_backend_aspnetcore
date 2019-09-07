/*
 * @CreateTime: Sep 7, 2019 12:56 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:01 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.WriteOffs.Models;
using FluentValidation;

namespace BionicERP.Application.Inventory.WriteOffs.Commands {
    public class CreateWriteOffCommandValidator : AbstractValidator<CreateWriteOffCommand> {
        public CreateWriteOffCommandValidator () {

            RuleFor (x => x.ItemId).NotNull ();
            RuleFor (x => x.Type).NotNull ();
            RuleForEach (x => x.WriteOffDetail).SetValidator (new WriteOffDetailValidator ());
        }

    }

    public class WriteOffDetailValidator : AbstractValidator<WriteOffItem> {
        public WriteOffDetailValidator () {
            RuleFor (x => x.BatchStorageId).NotNull ();
            RuleFor (x => x.Quantity).NotNull ();
        }
    }
}