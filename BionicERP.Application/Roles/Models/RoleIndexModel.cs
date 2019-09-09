/*
 * @CreateTime: Sep 9, 2019 5:49 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 9, 2019 5:49 PM 
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Identity;

namespace BionicERP.Application.Roles.Models {
    public class RoleIndexModel {
        public string Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<ApplicationRole, RoleIndexModel>> Projection {
            get {
                return role => new RoleIndexModel () {
                    Id = role.Id,
                    Name = role.Name
                };
            }
        }
    }
}