/*
 * @CreateTime: Sep 7, 2019 4:54 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 4:56 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand> {
        public CreateCustomerCommandValidator () {

            RuleFor (x => x.FullName).NotNull ().NotEmpty ();
            RuleFor (x => x.Type).NotNull ().NotEmpty ();
        }
    }
}