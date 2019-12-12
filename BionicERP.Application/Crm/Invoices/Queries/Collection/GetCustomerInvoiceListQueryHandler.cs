/*
 * @CreateTime: Dec 12, 2019 4:13 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 4:44 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.InvoicePayment.Models;
using BionicERP.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.Invoices.Queries {
    public class GetCustomerInvoiceListQueryHandler : IRequestHandler<GetCustomerInvoiceListQuery, IEnumerable<InvoicePaymentStatusView>> {
        private readonly IBionicERPDatabaseService _database;

        public GetCustomerInvoiceListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<InvoicePaymentStatusView>> Handle (GetCustomerInvoiceListQuery request, CancellationToken cancellationToken) {
            IEnumerable<InvoicePaymentStatusView> payments = await _database.Invoice
                .Select (InvoicePaymentStatusView.Projection)
                .Where (i => i.CustomerName.Contains (request.query))
                .ToListAsync ();

            return payments;
        }
    }
}