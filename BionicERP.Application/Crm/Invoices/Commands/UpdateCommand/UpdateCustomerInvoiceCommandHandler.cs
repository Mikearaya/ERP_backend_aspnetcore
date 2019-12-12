using System;
/*
 * @CreateTime: Dec 11, 2019 2:48 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 2:55 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Crm.Invoices.Models;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.Invoices.Commands {
    public class UpdateCustomerInvoiceCommandHandler : IRequestHandler<UpdateCustomerInvoiceCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public UpdateCustomerInvoiceCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateCustomerInvoiceCommand, Invoice> ();
                x.CreateMap<CustomerOrderInvoiceItemModel, InvoiceDetail> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateCustomerInvoiceCommand request, CancellationToken cancellationToken) {
            Invoice invoice = await _database.Invoice
                .Where (i => i.Id == request.Id)
                .Include (d => d.InvoiceDetail)
                .AsNoTracking ()
                .FirstOrDefaultAsync ();

            if (invoice == null) {
                throw new NotFoundException ("Customer Invoice", request.Id);
            }

            foreach (var item in invoice.InvoiceDetail) {
                var updated = request.InvoiceDetail.FirstOrDefault (c => c.Id == item.Id);
                if (updated == null) {
                    _database.InvoiceDetail.Remove (item);
                    continue;
                }

                item.DateUpdated = DateTime.Now;

            }

            _Mapper.Map (request, invoice);
            _database.Invoice.Update (invoice);
            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}