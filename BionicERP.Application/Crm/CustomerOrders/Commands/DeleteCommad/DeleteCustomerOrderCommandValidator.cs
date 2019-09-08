/*
 * @CreateTime: Sep 8, 2019 4:47 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 4:48 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Crm.CustomerOrders.Commands {
    public class DeleteCustomerOrderCommandValidator : AbstractValidator<DeleteCustomerOrderCommand> {
        public DeleteCustomerOrderCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
        }
    }
}