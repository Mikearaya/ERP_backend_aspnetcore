/*
 * @CreateTime: Dec 12, 2019 2:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 2:07 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;

namespace BionicERP.Application.Crm.InvoicePayment.Commands {
    public class UpdateCustomerInvoiceCommandHandler : IRequestHandler<UpdateCustomerInvoiceCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;

        public UpdateCustomerInvoiceCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateCustomerInvoiceCommand, InvoicePayments> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateCustomerInvoiceCommand request, CancellationToken cancellationToken) {
            InvoicePayments payments = await _database.InvoicePayments.FindAsync (request.Id);

            if (payments == null) {
                throw new NotFoundException ("Customer Invoice payment", request.Id);
            }

            _Mapper.Map (request, payments);
            _database.InvoicePayments.Update (payments);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}