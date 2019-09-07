/*
 * @CreateTime: Sep 7, 2019 5:09 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 7, 2019 5:09 PM 
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand> {
        public DeleteCustomerCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
        }
    }
}