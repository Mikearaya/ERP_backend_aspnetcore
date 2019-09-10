/*
 * @CreateTime: Sep 10, 2019 12:10 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:11 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using FluentValidation;

namespace BionicERP.Application.SystemLookups.Commands {
    public class UpdateSystemLookupCommandValidator : AbstractValidator<UpdateSystemLookupCommand> {
        public UpdateSystemLookupCommandValidator () {
            RuleFor (x => x.Lookups.Count ()).NotEqual (0);
            RuleForEach (x => x.Lookups).SetValidator (new NewSystemLookupValidator ());
        }
    }
}