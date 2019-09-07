/*
 * @CreateTime: Sep 7, 2019 2:01 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 2:03 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Inventory.StockBatchs.Models;
using MediatR;

namespace BionicERP.Application.Inventory.StockBatchs.Queries {
    public class GetStockBatchItemListQuery : IRequest<IEnumerable<StockBatchView>> {
        public uint ItemId { get; set; }
    }
}