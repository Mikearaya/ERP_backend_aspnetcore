/*
 * @CreateTime: Sep 10, 2019 12:15 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 10, 2019 12:15 PM 
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.SystemLookups.Commands {
    public class DeleteSystemLookupCommandValidator : AbstractValidator<DeleteSystemLookupCommand> {
        public DeleteSystemLookupCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
        }
    }
}