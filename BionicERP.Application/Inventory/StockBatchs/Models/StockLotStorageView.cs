/*
 * @CreateTime: Jan 10, 2019 8:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 19, 2019 9:38 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.StockBatchs.Models {
    public class StockLotStorageView {
        public uint Id { get; set; }
        public uint BatchId { get; set; }
        public uint StorageId { get; set; }
        public string Storage { get; set; }
        public uint? PreviousStorageId { get; set; }
        public string PreviousStorage { get; set; }
        public float Quantity { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<StockBatchStorage, StockLotStorageView>> Projection {

            get {
                return storage => new StockLotStorageView () {
                    Id = storage.Id,
                    BatchId = storage.BatchId,
                    StorageId = storage.StorageId,
                    Storage = storage.Storage.Name,
                    PreviousStorage = storage.PreviousStorage.Storage.Name,
                    PreviousStorageId = storage.PreviousStorageId,
                    Quantity = storage.Quantity,
                    DateAdded = storage.DateAdded,
                    DateUpdated = storage.DateUpdated
                };
            }
        }

        public static Expression<Func<StockBatchStorage, string>> StoragesProjection {

            get {
                return storage => storage.Storage.Name;
            }
        }

        public StockLotStorageView Create (StockBatchStorage lotStorage) {
            return Projection.Compile ().Invoke (lotStorage);
        }

    }
}