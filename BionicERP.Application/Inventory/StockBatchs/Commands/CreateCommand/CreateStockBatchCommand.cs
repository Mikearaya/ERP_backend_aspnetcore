/*
 * @CreateTime: Aug 9, 2019 11:28 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 11:48 AM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using BionicERP.Application.Inventory.StockBatchs.Models;
using MediatR;

namespace BionicERP.Application.Inventory.StockBatchs.Commands {
    public class CreateStockBatchCommand : IRequest<uint> {
        public uint ItemId { get; set; }
        public float Quantity { get; set; }
        public float UnitCost { get; set; }

        public string Status { get; set; }

        public uint? PurchaseOrderId { get; set; }

        public uint? ManufactureOrderId { get; set; }
        public DateTime? ArivalDate { get; set; }

        public DateTime AvailableFrom { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public List<NewStockBatchStorageDto> StorageLocation { get; set; } = new List<NewStockBatchStorageDto> ();

    }

}