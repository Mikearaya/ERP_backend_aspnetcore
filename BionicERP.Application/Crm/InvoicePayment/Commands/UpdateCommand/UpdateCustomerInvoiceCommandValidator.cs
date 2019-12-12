using FluentValidation;

namespace BionicERP.Application.Crm.InvoicePayment.Commands {
    public class UpdateCustomerInvoiceCommandValidator : AbstractValidator<UpdateCustomerInvoiceCommand> {
        public UpdateCustomerInvoiceCommandValidator () {
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
            RuleFor (x => x.Amount).NotNull ().NotEmpty ();
            RuleFor (x => x.CheckNo).NotNull ().NotEmpty ();
            RuleFor (x => x.InvoiceNo).NotNull ().NotEmpty ();
            RuleFor (x => x.Date).NotEmpty ().NotNull ();

        }
    }
}