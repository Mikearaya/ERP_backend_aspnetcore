/*
 * @CreateTime: Sep 8, 2019 4:51 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 4:53 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.CustomerOrders.Models {
    public class CustomerOrderItemView {

        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal? PricePerItem { get; set; }
        public decimal? SubTotal {
            get {
                return (decimal?) Quantity * PricePerItem;
            }
        }
        public decimal? TotalCost { get; set; }
        public decimal? Profit {
            get {
                return (decimal?) SubTotal - TotalCost;
            }
        }

        public uint ManufactureOrderId { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? TotalShipped { get; set; }

        public static Expression<Func<CustomerOrderItem, CustomerOrderItemView>> Projection {
            get {
                return order => new CustomerOrderItemView () {
                    Id = order.Id,
                    ItemId = order.ItemId,
                    Quantity = order.Quantity,
                    DueDate = order.DueDate,

                    PricePerItem = (decimal?) order.PricePerItem,
                    TotalCost = (decimal?) order.BookedStockBatch.Sum (o => o.BatchStorage.Batch.UnitCost * order.Quantity),
                    TotalShipped = (decimal?) order.BookedStockBatch.Sum (o => o.ShipmentDetail.Sum (q => q.PickedQuantity))

                };
            }
        }

    }
}