/*
 * @CreateTime: Aug 24, 2019 10:47 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 10:49 AM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.StorageLocations.Models {
    public class StorageLocationIndexModel {
        public uint Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<StorageLocation, StorageLocationIndexModel>> Projection {
            get {
                return location => new StorageLocationIndexModel () {
                    Id = location.Id,
                    Name = location.Name
                };
            }
        }
    }
}