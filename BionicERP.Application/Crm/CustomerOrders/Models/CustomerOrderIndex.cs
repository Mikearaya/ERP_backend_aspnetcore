/*
 * @CreateTime: Sep 8, 2019 4:55 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 4:57 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.CustomerOrders.Models {
    public class CustomerOrderIndex {
        public uint Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<CustomerOrder, CustomerOrderIndex>> Projection {
            get {
                return c => new CustomerOrderIndex () {
                    Id = c.Id,
                    Name = $"{c.Id} - ${c.Client.FullName}"
                };
            }
        }
    }

}