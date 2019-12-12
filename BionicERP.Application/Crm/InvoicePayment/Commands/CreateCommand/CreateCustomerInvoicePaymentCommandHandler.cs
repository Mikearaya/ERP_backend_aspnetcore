using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;

namespace BionicERP.Application.Crm.InvoicePayment.Commands {
    public class CreateCustomerInvoicePaymentCommandHandler : IRequestHandler<CreateCustomerInvoicePaymentCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;

        public CreateCustomerInvoicePaymentCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateCustomerInvoicePaymentCommand, InvoicePayments> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreateCustomerInvoicePaymentCommand request, CancellationToken cancellationToken) {
            Invoice invoice = await _database.Invoice.FindAsync (request.InvoiceNo);

            if (invoice == null) {
                throw new NotFoundException ("Invoice", request.InvoiceNo);
            }
            InvoicePayments payments = _Mapper.Map<CreateCustomerInvoicePaymentCommand, InvoicePayments> (request);
            await _database.InvoicePayments.AddAsync (payments);
            await _database.SaveAsync ();

            return payments.Id;

        }
    }
}