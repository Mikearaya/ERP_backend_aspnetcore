/*
 * @CreateTime: Sep 9, 2019 5:47 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 9, 2019 5:48 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.Identity;

namespace BionicERP.Application.Roles.Models {
    public class RoleViewModel {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<RoleClaimModel> Claims { get; set; } = new List<RoleClaimModel> ();

        public static Expression<Func<ApplicationRole, RoleViewModel>> Projection {
            get {
                return role => new RoleViewModel () {
                    Id = role.Id,
                    Name = role.Name,
                    Claims = role.RoleClaims.AsQueryable ().Select (RoleClaimModel.Projection)

                };
            }
        }

        public static Expression<Func<ApplicationRole, RoleViewModel>> ClaimLessProjection {
            get {
                return role => new RoleViewModel () {
                    Id = role.Id,
                    Name = role.Name,

                };
            }
        }
    }
}