/*
 * @CreateTime: Sep 7, 2019 1:19 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:20 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Inventory.WriteOffs.Commands {
    public class DeleteWriteOffCommand : IRequest {
        public uint Id { get; set; }
    }
}