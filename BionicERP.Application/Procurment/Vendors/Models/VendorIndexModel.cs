using System;
using System.Linq.Expressions;
using BionicERP.Domain.Procurment;
/*
 * @CreateTime: Aug 5, 2019 2:14 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:16 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Procurment.Vendors.Models {
    public class VendorIndexModel {
        public uint Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Vendor, VendorIndexModel>> Projection {
            get {
                return vendor => new VendorIndexModel () {
                    Id = vendor.Id,
                    Name = vendor.Name
                };
            }
        }
    }
}