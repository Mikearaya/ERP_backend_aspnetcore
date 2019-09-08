using System.Linq;
using BionicERP.Application.Crm.CustomerOrders.Models;
using BionicERP.Domain.CRM;
using FluentValidation;

namespace BionicERP.Application.Crm.CustomerOrders.Commands {
    public class CreateCustomerOrderCommandValidator : AbstractValidator<CreateCustomerOrderCommand> {
        public CreateCustomerOrderCommandValidator () {
            RuleFor (x => x.ClientId).NotNull ();
            RuleFor (x => x.OrderStatus).NotNull ().NotEmpty ();
            RuleFor (x => x.Description).NotNull ().NotEmpty ();
            RuleFor (x => x.CustomerOrderItem.Count ()).NotEqual (0);
            RuleForEach (x => x.CustomerOrderItem).SetValidator (new CustomerOrderItemValidator ());
        }
    }

    public class CustomerOrderItemValidator : AbstractValidator<CustomerOrderItemModel> {
        public CustomerOrderItemValidator () {
            RuleFor (x => x.ItemId).NotNull ();
            RuleFor (x => x.Quantity).NotEqual ('0');
            RuleFor (x => x.PricePerItem).NotNull ();

        }
    }
}