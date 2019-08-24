/*
 * @CreateTime: Aug 24, 2019 10:56 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 24, 2019 10:56 AM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Inventory.StorageLocations.Commands {
    public class UpdateStorageLocationCommand : IRequest {

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public sbyte? Active { get; set; }

    }
}