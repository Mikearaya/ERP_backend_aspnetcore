/*
 * @CreateTime: Dec 11, 2019 3:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 3:03 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Crm.Invoices.Commands {
    public class DeleteCustomerInvoiceCommandValidator : AbstractValidator<DeleteCustomerInvoiceCommand> {
        public DeleteCustomerInvoiceCommandValidator () {
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
        }
    }
}