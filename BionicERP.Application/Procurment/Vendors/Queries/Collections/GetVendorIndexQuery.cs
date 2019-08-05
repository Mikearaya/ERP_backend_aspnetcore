using System.Collections.Generic;
using BionicERP.Application.Procurment.Vendors.Models;
using MediatR;
/*
 * @CreateTime: Aug 5, 2019 2:16 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:36 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Procurment.Vendors.Queries {
    public class GetVendorIndexQuery : IRequest<IEnumerable<VendorIndexModel>> {
        private string VendorName { get; set; } = "";
        public string Name {
            get {
                return VendorName;
            }
            set {
                VendorName = (value == null) ? "" : value;
            }
        }
    }
}