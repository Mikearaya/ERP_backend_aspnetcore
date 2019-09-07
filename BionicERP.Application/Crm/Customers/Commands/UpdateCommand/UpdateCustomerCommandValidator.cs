/*
 * @CreateTime: Sep 7, 2019 5:03 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:04 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand> {
        public UpdateCustomerCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
            RuleFor (x => x.FullName).NotNull ().NotEmpty ();
            RuleFor (x => x.Type).NotNull ().NotEmpty ();
        }
    }
}