using MediatR;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Commands {
    public class DeleteUnitOfMeasurmentCommand : IRequest {

        public uint Id { get; set; }
    }
}