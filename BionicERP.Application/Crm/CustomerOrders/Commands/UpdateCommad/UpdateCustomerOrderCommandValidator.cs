/*
 * @CreateTime: Sep 8, 2019 4:37 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:16 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using FluentValidation;

namespace BionicERP.Application.Crm.CustomerOrders.Commands {
    public class UpdateCustomerOrderCommandValidator : AbstractValidator<UpdateCustomerOrderCommand> {
        public UpdateCustomerOrderCommandValidator () {

            RuleFor (x => x.Id).NotNull ();
            RuleFor (x => x.OrderStatus).NotNull ().NotEmpty ();
            RuleFor (x => x.Description).NotNull ().NotEmpty ();
            RuleFor (x => x.CustomerOrderItem.Count ()).NotEqual (0);
            RuleForEach (x => x.CustomerOrderItem).SetValidator (new CustomerOrderItemValidator ());
        }
    }
}