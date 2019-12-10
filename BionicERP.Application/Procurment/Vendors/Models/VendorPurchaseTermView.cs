/*
 * @CreateTime: Dec 10, 2019 3:27 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 10, 2019 4:11 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Procurment;

namespace BionicERP.Application.Procurment.Vendors.Models {
    public class VendorPurchaseTermView {
        public uint Id { get; set; }
        public string VendorProductId { get; set; }
        public string Item { get; set; }
        public string Uom { get; set; }
        public uint? Priority { get; set; }
        public uint? LeadTime { get; set; }
        public uint? MinimumQuantity { get; set; }
        public float UnitPrice { get; set; }

        public static Expression<Func<VendorPurchaseTerm, VendorPurchaseTermView>> Projection {
            get {
                return term => new VendorPurchaseTermView () {
                    Id = term.Id,
                    VendorProductId = term.VendorProductId,
                    Priority = term.Priority,
                    LeadTime = term.Leadtime,
                    MinimumQuantity = term.MinimumQuantity,
                    UnitPrice = term.UnitPrice,
                    Item = term.Item.Name,
                    Uom = term.Item.PrimaryUom.Abrivation
                };
            }
        }

    }
}