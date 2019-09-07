/*
 * @CreateTime: Sep 7, 2019 5:17 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:19 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.Customers.Models {
    public class CustomerPhoneNumberViewModel {

        public uint Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }

        public static Expression<Func<PhoneNumber, CustomerPhoneNumberViewModel>> Projection {
            get {
                return p => new CustomerPhoneNumberViewModel () {
                    Id = p.Id,
                    Type = p.Type,
                    Number = p.Number
                };
            }
        }
    }
}