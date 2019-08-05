/*
 * @CreateTime: Dec 23, 2018 10:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:25 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Procurment;

namespace BionicInventory.Application.Procurment.Vendors.Models {
    public class VendorView {

        public uint Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TinNumber { get; set; }
        public uint? LeadTime { get; set; }
        public uint? PaymentPeriod { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<Vendor, VendorView>> Projection {
            get {
                return vendor => new VendorView () {
                    Id = vendor.Id,
                    Name = vendor.Name,
                    PhoneNumber = vendor.PhoneNumber,
                    TinNumber = vendor.TinNumber,
                    LeadTime = vendor.LeadTime,
                    PaymentPeriod = vendor.PaymentPeriod,
                    DateAdded = vendor.DateAdded,
                    DateUpdated = vendor.DateUpdated
                };
            }
        }

        public static VendorView Create (Vendor vendor) {
            return Projection.Compile ().Invoke (vendor);
        }
    }
}