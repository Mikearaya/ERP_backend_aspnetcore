/*
 * @CreateTime: Aug 23, 2019 2:22 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:32 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Inventory.ProductGroups.Models;
using MediatR;

namespace BionicERP.Application.Inventory.ProductGroups.Queries {
    public class GetProductGroupIndexQuery : IRequest<IEnumerable<ProductGroupIndexModel>> {
        private string GroupName { get; set; } = "";
        public string Name {
            get {
                return GroupName;
            }
            set {
                GroupName = (value == null) ? "" : value;
            }
        }

    }
}