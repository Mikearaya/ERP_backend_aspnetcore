/*
 * @CreateTime: Sep 10, 2019 9:08 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:10 AM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Users.Commands {
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserPasswordCommand> {
        public UpdateUserCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
            RuleFor (x => x.CurrentPassword).NotEmpty ().NotNull ();
            RuleFor (x => x.NewPassword).NotEmpty ().NotNull ();
            RuleFor (x => x.ConfirmationPassword).NotNull ().NotEmpty ();
        }
    }
}