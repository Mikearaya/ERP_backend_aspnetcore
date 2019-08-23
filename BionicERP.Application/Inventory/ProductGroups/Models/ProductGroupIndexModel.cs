/*
 * @CreateTime: Aug 23, 2019 2:19 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:21 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.ProductGroups.Models {
    public class ProductGroupIndexModel {
        public uint Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<ProductGroup, ProductGroupIndexModel>> Projection {
            get {
                return group => new ProductGroupIndexModel () {
                    Id = group.Id,
                    Name = group.GroupName
                };
            }
        }

    }
}