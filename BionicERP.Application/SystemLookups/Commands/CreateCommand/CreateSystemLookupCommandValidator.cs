using System.Linq;
using BionicERP.Application.SystemLookups.Models;
/*
 * @CreateTime: Sep 10, 2019 11:59 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:02 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.SystemLookups.Commands {
    public class CreateSystemLookupCommandValidator : AbstractValidator<CreateSystemLookupCommand> {
        public CreateSystemLookupCommandValidator () {
            RuleFor (x => x.Lookups.Count ()).NotEqual (0);
            RuleForEach (x => x.Lookups).SetValidator (new NewSystemLookupValidator ());
        }
    }

    public class NewSystemLookupValidator : AbstractValidator<NewSystemLookupModel> {
        public NewSystemLookupValidator () {
            RuleFor (x => x.Type).NotEmpty ().NotNull ();
            RuleFor (x => x.Value).NotEmpty ().NotNull ();
        }
    }
}