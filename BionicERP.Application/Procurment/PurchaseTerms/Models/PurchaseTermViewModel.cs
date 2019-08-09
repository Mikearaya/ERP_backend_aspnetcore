/*
 * @CreateTime: Aug 5, 2019 9:52 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:54 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Procurment;

namespace BionicERP.Application.Procurment.PurchaseTerms.Models {
    public class PurchaseTermViewModel {
        public uint Id { get; set; }
        public uint VendorId { get; set; }
        public uint ItemId { get; set; }
        public string VendorProductId { get; set; }
        public uint? Priority { get; set; }
        public uint? Leadtime { get; set; }
        public uint? MinimumQuantity { get; set; }
        public float UnitPrice { get; set; }
        public string Item { get; set; }
        public string Vendor { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<VendorPurchaseTerm, PurchaseTermViewModel>> Projection {
            get {
                return term => new PurchaseTermViewModel () {
                    Id = term.Id,
                    Vendor = term.Vendor.Name,
                    Item = term.Item.Name,
                    VendorProductId = term.VendorProductId,
                    Priority = term.Priority,
                    Leadtime = (term.Leadtime == null) ? term.Vendor.LeadTime : term.Leadtime,
                    MinimumQuantity = term.MinimumQuantity,
                    UnitPrice = term.UnitPrice,
                    ItemId = term.ItemId,
                    VendorId = term.VendorId,
                    DateAdded = term.DateAdded,
                    DateUpdated = term.DateUpdated
                };
            }
        }

        public static PurchaseTermViewModel Create (VendorPurchaseTerm purchaseTerm) {
            return Projection.Compile ().Invoke (purchaseTerm);
        }
    }
}