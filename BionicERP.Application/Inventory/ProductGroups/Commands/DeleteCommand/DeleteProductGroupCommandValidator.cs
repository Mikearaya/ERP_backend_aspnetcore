/*
 * @CreateTime: Aug 23, 2019 2:10 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:11 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.ProductGroups.Commands {
    public class DeleteProductGroupCommandValidator : AbstractValidator<DeleteProductGroupCommand> {
        public DeleteProductGroupCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
        }
    }
}