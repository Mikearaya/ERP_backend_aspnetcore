/*
 * @CreateTime: Sep 2, 2019 4:39 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 2, 2019 4:41 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.StockBatchs.Models;
using MediatR;

namespace BionicERP.Application.Inventory.StockBatchs.Queries {
    public class GetStockBatchByIdQuery : IRequest<StockBatchDetailView> {
        public uint Id { get; set; }
    }
}