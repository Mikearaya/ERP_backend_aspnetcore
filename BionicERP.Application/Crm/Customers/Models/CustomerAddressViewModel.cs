/*
 * @CreateTime: Sep 7, 2019 5:14 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:17 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.Customers.Models {
    public class CustomerAddressViewModel {
        public uint Id { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public static Expression<Func<Address, CustomerAddressViewModel>> Projection {
            get {
                return a => new CustomerAddressViewModel () {
                    Id = a.Id,
                    Location = a.Location,
                    City = a.City,
                    SubCity = a.SubCity,
                    Country = a.Country,
                    PhoneNumber = a.PhoneNumber
                };
            }
        }
    }
}