/*
 * @CreateTime: Sep 10, 2019 8:52 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 8:53 AM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Users.Commands {
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand> {
        public CreateUserCommandValidator () {
            RuleFor (x => x.FullName).NotEmpty ().NotNull ();
            RuleFor (x => x.Email).EmailAddress ();
            RuleFor (x => x.RoleId).NotEmpty ().NotNull ();
        }
    }
}