/*
 * @CreateTime: Apr 25, 2019 3:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 25, 2019 3:12 PM
 * @Description: Modify Here, Please 
 */

using Microsoft.AspNetCore.Identity;

namespace BionicERP.Domain.Identity {
    public class RoleClaims : IdentityRoleClaim<string> {
        public ApplicationRole Role { get; set; }
    }
}