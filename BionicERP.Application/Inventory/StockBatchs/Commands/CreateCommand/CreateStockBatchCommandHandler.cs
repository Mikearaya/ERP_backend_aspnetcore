/*
 * @CreateTime: Aug 9, 2019 11:28 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 1:47 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.StockBatchs.Commands {
    public class CreateStockBatchCommandHandler : IRequestHandler<CreateStockBatchCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public CreateStockBatchCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateStockBatchCommand, StockBatch> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreateStockBatchCommand request, CancellationToken cancellationToken) {

            var item = await _database.Item
                .AsNoTracking ()
                .FirstOrDefaultAsync (i => i.Id == request.ItemId);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.ItemId);
            }
            StockBatch batch = _Mapper.Map<CreateStockBatchCommand, StockBatch> (request);

            if (request.Status.ToUpper () == "RECIEVED" || request.ArivalDate != null) {
                batch.ArrivalDate = (request.ArivalDate == null) ? DateTime.Now : request.ArivalDate;
            }
            batch.Source = "Manual";

            // check if manufacture order id is defined
            if (request.ManufactureOrderId != null && request.ManufactureOrderId != 0) {
                batch.Source = "Manufactured";
                batch.ManufactureOrderId = request.ManufactureOrderId;
            }

            // check if purchase order id is defined
            if (request.PurchaseOrderId != null && request.PurchaseOrderId != 0) {

                batch.Source = "Procured";
                batch.PurchaseOrderId = request.PurchaseOrderId;
            }

            if (request.ExpiryDate != null) {
                batch.ExpiryDate = request.ExpiryDate;
            } else if (item.ShelfLife != 0 && item.ShelfLife != null) {
                batch.ExpiryDate = request.AvailableFrom.AddDays ((double) item.ShelfLife);
            }

            if (request.StorageLocation.Count < 1) {
                throw new BelowRequiredMinimumItemException ("Stock Batch", 1, "Storage Location");
            }

            float storedQuantity = 0;
            foreach (var data in request.StorageLocation) {
                storedQuantity += data.Quantity;

                var store = await _database.StorageLocation.FindAsync (data.StorageId);

                if (store == null) {
                    throw new NotFoundException (nameof (StorageLocation), data.StorageId);
                }

                batch.StockBatchStorage.Add (new StockBatchStorage () {
                    StorageId = store.Id,
                        Quantity = data.Quantity
                });

            }

            // check if the sum of items allocated on each storage matchs the quantity stored in main 
            if (request.Quantity != storedQuantity) {
                throw new InequalMasterDetailQuantityException ("Item Batch", request.Quantity, storedQuantity);
            }

            _database.StockBatch.Add (batch);

            await _database.SaveAsync ();

            return batch.Id;
        }
    }
}