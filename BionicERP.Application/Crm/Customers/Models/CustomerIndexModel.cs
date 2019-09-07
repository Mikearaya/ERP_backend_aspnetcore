/*
 * @CreateTime: Sep 7, 2019 5:41 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:43 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.Customers.Models {
    public class CustomerIndexModel {
        public uint Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Customer, CustomerIndexModel>> Projection {
            get {
                return c => new CustomerIndexModel () {
                    Id = c.Id,
                    Name = c.FullName
                };
            }
        }
    }
}