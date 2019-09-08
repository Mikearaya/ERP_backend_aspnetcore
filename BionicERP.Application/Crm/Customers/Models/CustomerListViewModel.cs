/*
 * @CreateTime: Sep 7, 2019 5:29 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:23 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.Customers.Models {
    public class CustomerListViewModel {

        public uint Id { get; set; }
        public string FullName { get; set; }
        public string Tin { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public int? PaymentPeriod { get; set; }
        public double? CreditLimit { get; set; }
        public string PoBox { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<Customer, CustomerListViewModel>> Projection {
            get {
                return c => new CustomerListViewModel () {
                    Id = c.Id,
                    FullName = c.FullName,
                    Tin = c.Tin,
                    Email = c.Email,
                    Type = c.Type,
                    PaymentPeriod = (int?) c.PaymentPeriod,
                    CreditLimit = (double?) c.CreditLimit,
                    PoBox = c.PoBox,
                    DateAdded = c.DateAdded,
                    DateUpdated = c.DateUpdated
                };
            }
        }

    }
}