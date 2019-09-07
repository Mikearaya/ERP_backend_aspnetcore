/*
 * @CreateTime: Sep 2, 2019 4:40 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 2, 2019 4:42 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.StockBatchs.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.StockBatchs.Queries {
    public class GetStockBatchByIdQueryHandler : IRequestHandler<GetStockBatchByIdQuery, StockBatchDetailView> {

        private readonly IBionicERPDatabaseService _database;

        public GetStockBatchByIdQueryHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<StockBatchDetailView> Handle (GetStockBatchByIdQuery request, CancellationToken cancellationToken) {

            StockBatchDetailView stockBatch = await _database.StockBatch
                .Where (s => s.Id == request.Id)
                .Select (StockBatchDetailView.Projection)
                .FirstOrDefaultAsync ();

            if (stockBatch == null) {
                throw new NotFoundException ("Stock Batch", request.Id);
            }

            return stockBatch;
        }

    }
}