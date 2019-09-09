using System;
using System.Linq.Expressions;
using BionicERP.Domain.Identity;

namespace BionicERP.Application.Roles.Models {
    public class RoleClaimModel {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public static Expression<Func<RoleClaims, RoleClaimModel>> Projection {
            get {
                return claim => new RoleClaimModel () {
                    ClaimType = claim.ClaimType,
                    ClaimValue = claim.ClaimValue
                };
            }
        }

        public static Expression<Func<UserClaims, RoleClaimModel>> UserProjection {
            get {
                return claim => new RoleClaimModel () {
                    ClaimType = claim.ClaimType,
                    ClaimValue = claim.ClaimValue
                };
            }
        }
    }
}