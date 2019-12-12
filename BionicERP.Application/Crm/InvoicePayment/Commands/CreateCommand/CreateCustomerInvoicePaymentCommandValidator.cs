/*
 * @CreateTime: Dec 12, 2019 1:36 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 2:23 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Crm.InvoicePayment.Commands {
    public class CreateCustomerInvoicePaymentCommandValidator : AbstractValidator<CreateCustomerInvoicePaymentCommand> {
        public CreateCustomerInvoicePaymentCommandValidator () {
            RuleFor (x => x.Amount).NotNull ().NotEmpty ();
            RuleFor (x => x.CheckNo).NotNull ().NotEmpty ();
            RuleFor (x => x.InvoiceNo).NotNull ().NotEmpty ();
            RuleFor (x => x.Date).NotEmpty ().NotNull ();
        }
    }
}