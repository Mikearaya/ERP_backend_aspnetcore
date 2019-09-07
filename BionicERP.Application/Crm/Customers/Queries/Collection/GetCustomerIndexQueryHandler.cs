using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Crm.Customers.Models;
using BionicERP.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
/*
 * @CreateTime: Sep 7, 2019 5:44 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:48 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Crm.Customers.Queries {
    public class GetCustomerIndexQueryHandler : IRequestHandler<GetCustomerIndexQuery, IEnumerable<CustomerIndexModel>> {
        private readonly IBionicERPDatabaseService _database;

        public GetCustomerIndexQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<CustomerIndexModel>> Handle (GetCustomerIndexQuery request, CancellationToken cancellationToken) {
            IEnumerable<CustomerIndexModel> customerIndex = await _database.Customer
                .Where (c => c.FullName.ToUpper ().Contains (request.Name.ToUpper ()))
                .Select (CustomerIndexModel.Projection)
                .ToListAsync ();

            return customerIndex;
        }
    }
}