/*
 * @CreateTime: Jul 7, 2019 5:57 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 22, 2019 3:34 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Identity;

namespace BionicERP.Application.Security {
    public class SecurityManager {
        private readonly IBionicERPDatabaseService _securityDatabase;

        public SecurityManager (IBionicERPDatabaseService securityDatabase) {
            _securityDatabase = securityDatabase;
        }

        public AppUserAuth ValidateUser (ApplicationUser user) {

            AppUserAuth ret = new AppUserAuth ();
            ApplicationUser authUser = null;

            authUser = _securityDatabase.Users
                .Where (u => u.UserName.ToLower () == user.UserName.ToLower () && u.PasswordHash == user.PasswordHash)
                .FirstOrDefault ();

            if (authUser != null) {
                ret = BuildUserAuthObject (authUser);
            }
            return ret;
        }

        public List<RoleClaims> GetUserClaims (ApplicationUser authUser) {
            List<RoleClaims> list = new List<RoleClaims> ();

            try {
                list = (from a in _securityDatabase.UserRoles.Where (a => a.UserId == authUser.Id) join role in _securityDatabase.Roles on a.RoleId equals role.Id join roleClaim in _securityDatabase.RoleClaims on role.Id equals roleClaim.RoleId select new RoleClaims {
                        ClaimType = roleClaim.ClaimType,
                            ClaimValue = roleClaim.ClaimValue
                    })

                    .ToList ();
            } catch (Exception) {

            }

            return list;

        }

        public AppUserAuth BuildUserAuthObject (ApplicationUser authUser) {
            AppUserAuth ret = new AppUserAuth ();
            List<RoleClaims> claims = new List<RoleClaims> ();

            ret.UserName = authUser.UserName;
            ret.IsAuthenticated = true;
            ret.BearerToken = new Guid ().ToString ();

            ret.Claims = GetUserClaims (authUser);

            foreach (RoleClaims claim in claims) {

                try {
                    typeof (AppUserAuth).GetProperty (claim.ClaimType).SetValue (ret, Convert.ToBoolean (claim.ClaimValue), null);
                } finally {

                }

            }

            return ret;

        }

    }
}