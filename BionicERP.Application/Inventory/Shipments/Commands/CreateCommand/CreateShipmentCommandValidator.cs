/*
 * @CreateTime: Sep 7, 2019 3:44 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 3:51 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.Shipments.Models;
using FluentValidation;

namespace BionicERP.Application.Inventory.Shipments.Commands {
    public class CreateShipmentCommandValidator : AbstractValidator<CreateShipmentCommand> {
        public CreateShipmentCommandValidator () {
            RuleFor (x => x.DeliveryDate).NotNull ();
            RuleFor (x => x.Status).NotNull ();
            RuleForEach (x => x.ShipmentDetail).SetValidator (new NewShipmentItemValidator ());

        }
    }

    public class NewShipmentItemValidator : AbstractValidator<ShipmentItem> {
        public NewShipmentItemValidator () {
            RuleFor (x => x.LotBookingId).NotNull ();
            RuleFor (x => x.BookedQuantity).NotNull ();
        }
    }
}