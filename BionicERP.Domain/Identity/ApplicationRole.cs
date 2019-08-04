/*
 * @CreateTime: Apr 25, 2019 3:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 3:11 PM
 * @Description: Modify Here, Please 
 */

using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BionicERP.Domain.Identity {
    public class ApplicationRole : IdentityRole<string> {
        public ApplicationRole () {
            RoleClaims = new HashSet<RoleClaims> ();
            UserRoles = new HashSet<UserRoles> ();
        }
        public string Access { get; set; }
        public ICollection<RoleClaims> RoleClaims { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}