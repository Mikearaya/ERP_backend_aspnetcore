/*
 * @CreateTime: Aug 24, 2019 11:02 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 24, 2019 11:02 AM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Inventory.StorageLocations.Commands {
    public class DeleteStorageLocationCommand : IRequest {
        public uint Id { get; set; }
    }
}