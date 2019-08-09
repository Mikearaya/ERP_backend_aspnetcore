using System.Collections.Generic;
using BionicERP.Application.Inventory.Items.Models;
/*
 * @CreateTime: Aug 5, 2019 9:06 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:09 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Inventory.Items.Queries {
    public class GetItemIndexQuery : IRequest<IEnumerable<ItemIndexModel>> {

        private string Search { get; set; } = "";
        public string SearchString {
            get {
                return Search;
            }
            set {
                Search = (value == null) ? "" : value;
            }
        }

        public uint VendorId { get; set; }
    }
}