using System.Collections.Generic;
using BionicERP.Application.Crm.Customers.Models;
/*
 * @CreateTime: Sep 7, 2019 4:49 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 4:54 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class CreateCustomerCommand : IRequest<uint> {
        public string FullName { set; get; }

        public string Tin { set; get; }
        public string Email { set; get; }

        public int? PaymentPeriod { get; set; }
        public double? CreditLimit { get; set; }
        public string PoBox { get; set; }
        public double? TaxAmount { get; set; }

        public string Type { set; get; }

        public IEnumerable<CustomerSocialMediaModel> SocialMedia { get; set; }
        public IEnumerable<CustomerAddressModel> Address { get; set; }
        public IEnumerable<CustomerPhoneNumberModel> PhoneNumber { get; set; }
    }
}