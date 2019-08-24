/*
 * @CreateTime: Aug 24, 2019 11:13 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 24, 2019 11:13 AM 
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.StorageLocations.Models;
using MediatR;

namespace BionicERP.Application.Inventory.StorageLocations.Queries {
    public class GetStorageLocationByIdQuery : IRequest<StorageLocationViewModel> {
        public uint Id { get; set; }
    }
}