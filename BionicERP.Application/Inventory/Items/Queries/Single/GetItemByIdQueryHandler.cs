/*
 * @CreateTime: Aug 24, 2019 12:14 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 12:17 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicInventory.Application.Stocks.Items.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.Items.Queries {
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemViewModel> {
        private readonly IBionicERPDatabaseService _database;

        public GetItemByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<ItemViewModel> Handle (GetItemByIdQuery request, CancellationToken cancellationToken) {
            ItemViewModel item = await _database.Item
                .Select (ItemViewModel.Projection)
                .FirstOrDefaultAsync (i => i.Id == request.Id);

            if (item == null) {
                throw new NotFoundException ("Item", request.Id);
            }

            return item;
        }
    }
}