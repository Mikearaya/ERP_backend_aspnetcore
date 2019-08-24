using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.StorageLocations.Models {
    public class StorageLocationViewModel {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<StorageLocation, StorageLocationViewModel>> Projection {

            get {
                return storage => new StorageLocationViewModel {
                    Id = storage.Id,
                    Name = storage.Name,
                    Note = storage.Note,
                    Active = (storage.Active != 0) ? true : false,
                    DateAdded = storage.DateAdded,
                    DateUpdated = storage.DateUpdated,
                };
            }

        }

        public static StorageLocationViewModel Create (StorageLocation storageLocation) {
            return Projection.Compile ().Invoke (storageLocation);
        }
    }
}