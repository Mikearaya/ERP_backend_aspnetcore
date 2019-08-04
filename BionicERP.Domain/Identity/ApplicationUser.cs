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
    public class ApplicationUser : IdentityUser<string> {
        public ApplicationUser () {
            UserClaims = new HashSet<UserClaims> ();
            UserLogins = new HashSet<UserLogins> ();
            UserRoles = new HashSet<UserRoles> ();
            UserTokens = new HashSet<UserTokens> ();
        }
        public ICollection<UserClaims> UserClaims { get; set; }
        public ICollection<UserLogins> UserLogins { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
        public ICollection<UserTokens> UserTokens { get; set; }
    }
}