/*
 * @CreateTime: Aug 24, 2019 11:06 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 11:07 AM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Inventory.StorageLocations.Models;
using MediatR;

namespace BionicERP.Application.Inventory.StorageLocations.Queries {
    public class GetStorageLocationIndexQuery : IRequest<IEnumerable<StorageLocationIndexModel>> {
        private string StorageName { get; set; } = "";
        public string Name {
            get {
                return StorageName;
            }
            set {
                StorageName = (value == null) ? "" : value;
            }
        }
    }
}