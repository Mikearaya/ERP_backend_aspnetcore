/*
 * @CreateTime: Dec 12, 2019 1:50 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 1:57 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.InvoicePayment.Models;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.InvoicePayment.Queries {
    public class GetCustomerInvoicePaymentByIdHandler : IRequestHandler<GetCustomerInvoicePaymentById, InvoicePaymentListView> {
        private readonly IBionicERPDatabaseService _database;

        public GetCustomerInvoicePaymentByIdHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<InvoicePaymentListView> Handle (GetCustomerInvoicePaymentById request, CancellationToken cancellationToken) {
            InvoicePaymentListView payment = await _database.InvoicePayments
                .Where (i => i.InvoiceNoNavigation != null)
                .Select (InvoicePaymentListView.Projection)

                .FirstOrDefaultAsync (i => i.Id == request.Id);

            if (payment == null) {
                throw new NotFoundException ("Customer Invoice Payment", request.Id);
            }
            return payment;
        }
    }
}