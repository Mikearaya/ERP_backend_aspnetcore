/*
 * @CreateTime: Aug 23, 2019 1:57 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 23, 2019 1:57 PM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Inventory.ProductGroups.Commands {
    public class CreateProductGroupCommand : IRequest<uint> {

        public string GroupName { get; set; }
        public string Description { get; set; }
        public uint? ParentGroup { get; set; }

    }
}