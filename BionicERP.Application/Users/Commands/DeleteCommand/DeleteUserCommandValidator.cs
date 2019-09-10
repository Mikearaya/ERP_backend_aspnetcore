/*
 * @CreateTime: Sep 10, 2019 9:04 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:05 AM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Users.Commands {
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand> {
        public DeleteUserCommandValidator () {
            RuleFor (x => x.Id).NotEmpty ().NotNull ();
        }

    }
}