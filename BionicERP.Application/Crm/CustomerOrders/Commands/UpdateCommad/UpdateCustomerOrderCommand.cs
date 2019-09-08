/*
 * @CreateTime: Sep 8, 2019 4:33 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:16 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using BionicERP.Application.Crm.CustomerOrders.Models;
using MediatR;

namespace BionicERP.Application.Crm.CustomerOrders.Commands {
    public class UpdateCustomerOrderCommand : IRequest {

        public uint Id { get; set; }
        public string OrderStatus { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public IEnumerable<CustomerOrderItemModel> CustomerOrderItem { get; set; } = new List<CustomerOrderItemModel> ();

    }
}