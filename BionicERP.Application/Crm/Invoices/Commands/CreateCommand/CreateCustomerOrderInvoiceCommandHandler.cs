/*
 * @CreateTime: Dec 11, 2019 1:59 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 2:03 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Crm.Invoices.Models;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;

namespace BionicERP.Application.Crm.Invoices.Commands {
    public class CreateCustomerOrderInvoiceCommandHandler : IRequestHandler<CreateCustomerOrderInvoiceCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public CreateCustomerOrderInvoiceCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateCustomerOrderInvoiceCommand, Invoice> ();
                x.CreateMap<CustomerOrderInvoiceItemModel, InvoiceDetail> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreateCustomerOrderInvoiceCommand request, CancellationToken cancellationToken) {
            Invoice newInvoice = _Mapper.Map<CreateCustomerOrderInvoiceCommand, Invoice> (request);

            await _database.Invoice.AddAsync (newInvoice);
            await _database.SaveAsync ();

            return newInvoice.Id;
        }
    }
}