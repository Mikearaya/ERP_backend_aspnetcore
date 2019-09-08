using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.CustomerOrders.Models;
using BionicERP.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
/*
 * @CreateTime: Sep 8, 2019 5:10 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:13 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Crm.CustomerOrders.Queries {
    public class GetCustomerOrderIndexQueryHandler : IRequestHandler<GetCustomerOrderIndexQuery, IEnumerable<CustomerOrderIndex>> {
        private readonly IBionicERPDatabaseService _database;

        public GetCustomerOrderIndexQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<CustomerOrderIndex>> Handle (GetCustomerOrderIndexQuery request, CancellationToken cancellationToken) {
            return await _database.CustomerOrder
                .Select (CustomerOrderIndex.Projection)
                .Where (c => c.Name.ToUpper ().Contains (request.Name.ToUpper ()))
                .ToListAsync ();
        }
    }
}