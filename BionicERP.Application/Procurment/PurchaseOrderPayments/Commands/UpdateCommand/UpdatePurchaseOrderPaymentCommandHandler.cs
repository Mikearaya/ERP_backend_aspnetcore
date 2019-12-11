/*
 * @CreateTime: Aug 15, 2019 7:36 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 7:40 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Commands {
    public class UpdatePurchaseOrderPaymentCommandHandler : IRequestHandler<UpdatePurchaseOrderPaymentCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mappper;
        public UpdatePurchaseOrderPaymentCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mappper = new MapperConfiguration (x => {
                x.CreateMap<UpdatePurchaseOrderPaymentCommand, InvoicePayments> ();

            }).
            CreateMapper ();
        }

        public async Task<Unit> Handle (UpdatePurchaseOrderPaymentCommand request, CancellationToken cancellationToken) {
            InvoicePayments payment = await _database.InvoicePayments.FindAsync (request.Id);

            if (payment == null) {
                throw new NotFoundException ("Payment", request.Id);
            }

            _Mappper.Map (request, payment);
            _database.InvoicePayments.Update (payment);
            await _database.SaveAsync ();
            return Unit.Value;
        }
    }
}