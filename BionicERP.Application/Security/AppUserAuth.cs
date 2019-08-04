/*
 * @CreateTime: Jul 7, 2019 5:58 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 22, 2019 3:34 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Domain.Identity;

namespace BionicERP.Application.Security {
    public class AppUserAuth {
        public AppUserAuth () : base () {
            UserName = "Not Authorized";
            BearerToken = string.Empty;

        }

        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public IList<RoleClaims> Claims = new List<RoleClaims> ();
    }
}