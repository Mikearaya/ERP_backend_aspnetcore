/*
 * @CreateTime: Sep 7, 2019 5:29 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 6:10 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.Customers.Models {
    public class CustomerListViewModel {

        public uint Id;
        public string FullName;
        public string Tin;
        public string Email;
        public string Type;
        public int? PaymentPeriod;
        public double? CreditLimit;
        public string PoBox;
        public DateTime? DateAdded;
        public DateTime? DateUpdated;

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