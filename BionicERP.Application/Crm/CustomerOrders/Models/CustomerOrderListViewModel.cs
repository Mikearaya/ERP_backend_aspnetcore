/*
 * @CreateTime: Sep 8, 2019 5:01 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:23 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.CustomerOrders.Models {
    public class CustomerOrderListViewModel {
        public uint Id { get; set; }
        public decimal? TotalQuantity { get; set; }
        public uint CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal? TotalPrice { get; set; }

        public decimal? TotalCost { get; set; }
        public decimal? Profit {
            get {
                return (decimal?) TotalPrice - TotalCost;
            }
            set { }
        }
        public string Status { get; set; }

        public string ProductStatus { get; set; }
        public string InvoiceStatus { get; set; }
        public string PaymentStatus { get; set; }
        public uint? totalShipped { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public static Expression<Func<CustomerOrder, CustomerOrderListViewModel>> Projection {
            get {
                return order => new CustomerOrderListViewModel () {
                    Id = order.Id,
                    CustomerId = order.ClientId,
                    CustomerName = order.Client.FullName,
                    Status = order.OrderStatus,
                    TotalCost = (decimal?) order.CustomerOrderItem.AsQueryable ()
                    .Sum (o => o.BookedStockBatch
                    .Sum (s => s.BatchStorage.Batch.UnitCost * o.Quantity)),
                    TotalPrice = (decimal?) order.CustomerOrderItem.Sum (o => o.PricePerItem * o.Quantity),
                    TotalQuantity = order.CustomerOrderItem.Sum (o => o.Quantity),
                    DeliveryDate = order.DueDate,
                    DateAdded = order.DateAdded,
                    DateUpdated = order.DateUpdated
                };
            }
        }
    }
}