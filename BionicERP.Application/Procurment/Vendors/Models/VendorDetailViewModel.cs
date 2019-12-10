/*
 * @CreateTime: Dec 10, 2019 3:26 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 10, 2019 3:46 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.Procurment;

namespace BionicERP.Application.Procurment.Vendors.Models {
    public class VendorDetailViewModel {

        public uint Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TinNumber { get; set; }
        public uint? LeadTime { get; set; }
        public uint? PaymentPeriod { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public IEnumerable<VendorPurchaseTermView> VendorPurchaseTerm { get; set; }

        public static Expression<Func<Vendor, VendorDetailViewModel>> Projection {
            get {
                return vendor => new VendorDetailViewModel () {
                    Id = vendor.Id,
                    Name = vendor.Name,
                    PhoneNumber = vendor.PhoneNumber,
                    TinNumber = vendor.TinNumber,
                    LeadTime = vendor.LeadTime,
                    PaymentPeriod = vendor.PaymentPeriod,
                    DateAdded = vendor.DateAdded,
                    DateUpdated = vendor.DateUpdated,
                    VendorPurchaseTerm = vendor.VendorPurchaseTerm
                    .AsQueryable ()
                    .Select (VendorPurchaseTermView.Projection)

                };
            }
        }

        public static VendorDetailViewModel Create (Vendor vendor) {
            return Projection.Compile ().Invoke (vendor);
        }

    }
}