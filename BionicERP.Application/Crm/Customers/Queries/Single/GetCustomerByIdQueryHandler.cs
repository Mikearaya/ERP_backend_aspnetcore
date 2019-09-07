/*
 * @CreateTime: Sep 7, 2019 5:37 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:39 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.Customers.Models;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.Customers.Queries {
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDetailViewModel> {
        private readonly IBionicERPDatabaseService _database;

        public GetCustomerByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<CustomerDetailViewModel> Handle (GetCustomerByIdQuery request, CancellationToken cancellationToken) {
            CustomerDetailViewModel customer = await _database.Customer
                .Select (CustomerDetailViewModel.Projection)
                .FirstOrDefaultAsync (c => c.Id == request.Id);

            if (customer == null) {
                throw new NotFoundException ("Customer", request.Id);
            }

            return customer;
        }
    }
}