using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;
/*
 * @CreateTime: Aug 5, 2019 9:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:04 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Inventory.Items.Models {
    public class ItemIndexModel {
        public uint Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Item, ItemIndexModel>> Projection {
            get {
                return item => new ItemIndexModel () {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                };

            }
        }

    }
}