/*
 * @CreateTime: Aug 24, 2019 12:14 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 24, 2019 12:14 PM 
 * @Description: Modify Here, Please  
 */
using BionicInventory.Application.Stocks.Items.Models;
using MediatR;

namespace BionicERP.Application.Inventory.Items.Queries {
    public class GetItemByIdQuery : IRequest<ItemViewModel> {
        public uint Id { get; set; }
    }
}