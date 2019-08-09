/*
 * @CreateTime: Aug 5, 2019 8:54 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 8:55 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.Items.Commands {
    public class DeleteItemCommandValidator : AbstractValidator<DeleteItemCommand> {
        public DeleteItemCommandValidator () {
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
        }
    }
}