/*
 * @CreateTime: Sep 7, 2019 5:19 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:21 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.Customers.Models {
    public class CustomerSocialMediaViewModel {
        public uint Id { get; set; }
        public string Site { get; set; }
        public string Address { get; set; }

        public static Expression<Func<SocialMedia, CustomerSocialMediaViewModel>> Projection {
            get {
                return s => new CustomerSocialMediaViewModel () {
                    Id = s.Id,
                    Site = s.Site,
                    Address = s.Address
                };
            }
        }
    }
}