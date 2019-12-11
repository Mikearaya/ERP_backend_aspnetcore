using FluentValidation;

namespace BionicERP.Application.Crm.Invoices.Commands {
    public class CreateCustomerOrderInvoceValidator : AbstractValidator<CreateCustomerOrderInvoiceCommand> {
        public CreateCustomerOrderInvoceValidator () {
            RuleFor (x => x.InvoiceType).NotEmpty ().NotNull ();
            RuleFor (x => x.PaymentMethod).NotEmpty ().NotNull ();
            RuleFor (x => x.PurchaseOrderId).NotNull ().NotNull ();
        }
    }
}