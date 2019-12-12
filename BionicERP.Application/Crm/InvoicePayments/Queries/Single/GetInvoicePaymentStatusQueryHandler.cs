/*
 * @CreateTime: Dec 12, 2019 11:25 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 11:30 AM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.InvoicePayments.Models;
using BionicERP.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.InvoicePayments.Queries {
    public class GetInvoicePaymentStatusQueryHandler : IRequestHandler<GetInvoicePaymentStatusQuery, InvoicePaymentStatusView> {
        private readonly IBionicERPDatabaseService _database;

        public GetInvoicePaymentStatusQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<InvoicePaymentStatusView> Handle (GetInvoicePaymentStatusQuery request, CancellationToken cancellationToken) {
            return await _database.Invoice
                .Select (InvoicePaymentStatusView.Projection)
                .FirstOrDefaultAsync (p => p.InvoiceId == request.Id);
        }
    }
}