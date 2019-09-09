using System.Linq;
/*
 * @CreateTime: Sep 9, 2019 5:29 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:36 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Roles.Commands {
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand> {
        public CreateRoleCommandValidator () {
            RuleFor (x => x.Name).NotEmpty ().NotNull ();
            RuleFor (x => x.Claims.Count ()).NotEqual (0);
        }
    }
}