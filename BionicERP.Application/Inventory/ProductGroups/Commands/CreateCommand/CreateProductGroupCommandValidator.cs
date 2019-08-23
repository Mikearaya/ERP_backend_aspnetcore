/*
 * @CreateTime: Aug 23, 2019 1:58 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 23, 2019 1:58 PM 
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.ProductGroups.Commands {
    public class CreateProductGroupCommandValidator : AbstractValidator<CreateProductGroupCommand> {
        public CreateProductGroupCommandValidator () {
            RuleFor (x => x.GroupName).NotNull ().NotEmpty ();
        }
    }
}