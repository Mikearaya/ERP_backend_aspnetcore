/*
 * @CreateTime: Sep 9, 2019 5:39 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:40 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using FluentValidation;

namespace BionicERP.Application.Roles.Commands {
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand> {
        public UpdateRoleCommandValidator () {
            RuleFor (x => x.Id).NotEmpty ().NotNull ();
            RuleFor (x => x.Name).NotEmpty ().NotNull ();
            RuleFor (x => x.Claims.Count ()).NotEqual (0);

        }
    }
}