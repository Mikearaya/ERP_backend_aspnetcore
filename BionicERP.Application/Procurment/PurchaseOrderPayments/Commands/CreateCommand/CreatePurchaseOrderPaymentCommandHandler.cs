/*
 * @CreateTime: Aug 15, 2019 7:31 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 8:01 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Commands {
    public class CreatePurchaseOrderPaymentCommandHandler : IRequestHandler<CreatePurchaseOrderPaymentCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public CreatePurchaseOrderPaymentCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreatePurchaseOrderPaymentCommand, InvoicePayments> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreatePurchaseOrderPaymentCommand request, CancellationToken cancellationToken) {
            InvoicePayments payment = _Mapper.Map<CreatePurchaseOrderPaymentCommand, InvoicePayments> (request);

            await _database.InvoicePayments.AddAsync (payment);
            await _database.SaveAsync ();

            return payment.Id;
        }
    }
}