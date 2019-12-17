using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Inventory.Shipments.Models {
    public class RemainingCustomerOrderShipmentModel {
        public uint ItemId { get; set; }
        public string Item { get; set; }
        public uint OrderedQuantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public uint ShippedQuantity { get; set; }

        public static Expression<Func<CustomerOrderItem, RemainingCustomerOrderShipmentModel>> Projection {
            get {
                return shipment => new RemainingCustomerOrderShipmentModel () {
                    ItemId = shipment.ItemId,
                    Item = shipment.Item.Name,
                    OrderedQuantity = shipment.Quantity,
                    RemainingQuantity = shipment.BookedStockItems.Sum (c => c.BookedForNavigation.Quantity),

                };
            }
        }
    }
}