/*
 * @CreateTime: Sep 10, 2019 9:14 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 10, 2019 9:14 AM 
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Identity;

namespace BionicERP.Application.Users.Models {
    public class UserIndexModel {

        public string Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<ApplicationUser, UserIndexModel>> Projection {
            get {
                return user => new UserIndexModel () {
                    Id = user.Id,
                    Name = user.UserName,

                };
            }
        }

    }
}