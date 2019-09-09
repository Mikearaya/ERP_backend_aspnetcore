/*
 * @CreateTime: Sep 9, 2019 5:44 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:46 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Roles.Commands {
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand> {
        public DeleteRoleCommandValidator () {
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
        }
    }
}