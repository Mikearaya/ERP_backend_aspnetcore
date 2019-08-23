/*
 * @CreateTime: Aug 23, 2019 2:10 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 23, 2019 2:10 PM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Inventory.ProductGroups.Commands {
    public class DeleteProductGroupCommand : IRequest {
        public uint Id { get; set; }
    }
}