/*
 * @CreateTime: Dec 11, 2019 1:44 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 11, 2019 1:50 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.Invoices.Models;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.Invoices.Queries {
    public class GetCustomerOrderInvoiceByIdHandler : IRequestHandler<GetCustomerOrderInvoiceById, CustomerOrderInvoiceDetail> {
        private readonly IBionicERPDatabaseService _database;

        public GetCustomerOrderInvoiceByIdHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<CustomerOrderInvoiceDetail> Handle (GetCustomerOrderInvoiceById request, CancellationToken cancellationToken) {
            CustomerOrderInvoiceDetail detail = await _database.Invoice
                .Select (CustomerOrderInvoiceDetail.Projection)
                .FirstOrDefaultAsync (r => r.Id == request.Id);

            if (detail == null) {
                throw new NotFoundException ("Customer order invoice", request.Id);
            }

            return detail;
        }
    }
}