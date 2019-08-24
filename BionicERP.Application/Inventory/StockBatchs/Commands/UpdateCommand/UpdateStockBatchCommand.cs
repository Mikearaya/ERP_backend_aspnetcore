/*
 * @CreateTime: Aug 24, 2019 4:54 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 4:55 PM
 * @Description: Modify Here, Please  
 */
using System;
using MediatR;

namespace BionicERP.Application.Inventory.StockBatchs.Commands {
    public class UpdateStockBatchCommand : IRequest {
        public uint Id { get; set; }
        public string Status { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ArivalDate { get; set; }
    }
}