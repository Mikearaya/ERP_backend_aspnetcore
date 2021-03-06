/*
 * @CreateTime: Sep 8, 2019 4:51 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 4:53 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.CustomerOrders.Models {
    public class CustomerOrderDetailViewModel {

        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public string CustomerName { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public string CreatedBy { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<CustomerOrderItemView> CustomerOrderItem = new List<CustomerOrderItemView> ();

        public static Expression<Func<CustomerOrder, CustomerOrderDetailViewModel>> Projection {
            get {
                return order => new CustomerOrderDetailViewModel () {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    CustomerName = order.Client.FullName,
                    OrderStatus = order.OrderStatus,
                    DueDate = order.DueDate,
                    DateAdded = order.DateAdded,
                    DateUpdated = order.DateUpdated,
                    Description = order.Description,
                    CustomerOrderItem = order.CustomerOrderItem.AsQueryable ().Select (CustomerOrderItemView.Projection)

                };
            }
        }

    }
}