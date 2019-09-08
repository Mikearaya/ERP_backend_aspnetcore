/*
 * @CreateTime: Sep 8, 2019 4:21 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 4:31 PM
 * @Description: Modify Here, Please  
 */
using System;

namespace BionicERP.Application.Crm.CustomerOrders.Models {
    public class CustomerOrderItemModel {
        public uint? Id { get; set; }

        public uint ItemId { get; set; }

        public uint Quantity { get; set; }

        public DateTime DueDate { get; set; }

        public float PricePerItem { get; set; }
    }
}