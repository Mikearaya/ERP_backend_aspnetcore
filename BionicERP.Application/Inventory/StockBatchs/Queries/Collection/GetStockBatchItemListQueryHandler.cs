using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.StockBatchs.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
/*
 * @CreateTime: Sep 7, 2019 2:01 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 2:03 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Inventory.StockBatchs.Queries {
    public class GetStockBatchItemListQueryHandler : IRequestHandler<GetStockBatchItemListQuery, IEnumerable<StockBatchView>> {
        private readonly IBionicERPDatabaseService _database;

        public GetStockBatchItemListQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<StockBatchView>> Handle (GetStockBatchItemListQuery request, CancellationToken cancellationToken) {
            return await _database.StockBatchStorage
                .Where (lot => lot.Batch.ItemId == request.ItemId)
                .Select (StockBatchView.Projection)
                .ToListAsync ();
        }
    }
}