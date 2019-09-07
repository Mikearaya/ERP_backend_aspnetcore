/*
 * @CreateTime: Sep 7, 2019 3:53 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 3:54 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.Shipments.Models;
using FluentValidation;

namespace BionicERP.Application.Inventory.Shipments.Commands {
    public class UpdateShipmentCommandValidator : AbstractValidator<UpdateShipmentCommand> {
        public UpdateShipmentCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
            RuleFor (x => x.DeliveryDate).NotNull ();
            RuleFor (x => x.Status).NotNull ();
            RuleForEach (x => x.ShipmentDetail).SetValidator (new UpdatedShipmentItemValidator ());
        }
    }
    public class UpdatedShipmentItemValidator : AbstractValidator<ShipmentItem> {
        public UpdatedShipmentItemValidator () {
            RuleFor (x => x.LotBookingId).NotNull ();
            RuleFor (x => x.BookedQuantity).NotNull ();
        }
    }
}