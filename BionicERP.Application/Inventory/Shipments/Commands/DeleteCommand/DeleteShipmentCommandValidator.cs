/*
 * @CreateTime: Sep 7, 2019 4:00 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 7, 2019 4:00 PM 
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.Shipments.Commands {
    public class DeleteShipmentCommandValidator : AbstractValidator<DeleteShipmentCommand> {
        public DeleteShipmentCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
        }
    }
}