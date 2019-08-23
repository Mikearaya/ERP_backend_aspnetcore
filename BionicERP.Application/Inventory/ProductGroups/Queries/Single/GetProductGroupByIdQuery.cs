/*
 * @CreateTime: Aug 23, 2019 2:27 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:30 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.ProductGroups.Models;
using MediatR;

namespace BionicERP.Application.Inventory.ProductGroups.Queries {
    public class GetProductGroupByIdQuery : IRequest<ProductGroupViewModel> {
        public uint Id { get; set; }
    }
}