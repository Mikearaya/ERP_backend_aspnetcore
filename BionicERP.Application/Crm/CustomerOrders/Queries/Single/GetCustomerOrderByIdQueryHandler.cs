/*
 * @CreateTime: Sep 8, 2019 4:58 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:19 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.CustomerOrders.Models;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.CustomerOrders.Queries {
    public class GetCustomerOrderByIdQueryHandler : IRequestHandler<GetCustomerOrderByIdQuery, CustomerOrderDetailViewModel> {
        private readonly IBionicERPDatabaseService _database;

        public GetCustomerOrderByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<CustomerOrderDetailViewModel> Handle (GetCustomerOrderByIdQuery request, CancellationToken cancellationToken) {
            CustomerOrderDetailViewModel customerOrder = await _database.CustomerOrder
                .Select (CustomerOrderDetailViewModel.Projection)
                .FirstOrDefaultAsync (x => x.Id == request.Id);

            if (customerOrder == null) {
                throw new NotFoundException ("Customer Order", request.Id);
            }

            return customerOrder;
        }
    }
}