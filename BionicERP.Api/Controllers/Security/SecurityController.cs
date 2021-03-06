/*
 * @CreateTime: Apr 25, 2019 9:35 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 1:46 PMM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BionicERP.Api.Configurations;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Models;
using BionicERP.Application.Security;
using BionicERP.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BionicERP.Api.Controllers.Security {

    /// <summary>
    /// handles security related functions in the system such as
    /// logging a user and issuing valid jwt token
    /// </summary>
    [Route ("security")]
    public class SecurityController : Controller {
        private readonly JwtSettings _settings;
        private readonly IMediator _Mediator;
        private readonly IBionicERPDatabaseService _database;

        /// <summary>
        /// constructor for security controller
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="mediator"></param>
        /// <param name="database"></param>
        public SecurityController (JwtSettings settings, IMediator mediator, IBionicERPDatabaseService database) {
            _settings = settings;
            _Mediator = mediator;
            _database = database;
        }

        /// <summary>
        /// handles login request from the user 
        /// and return a valid jwt token on success or 
        /// error message on failure
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost ("login")]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<AppUserAuth>> LogIn ([FromBody] AuthenticationQuery user) {

            try {
                var x = await ValidateUser (user);

                return StatusCode (200, x);
            } catch (NotFoundException e) {
                return StatusCode (404, e.Message);
            }

        }

        /// <summary>
        /// used to validate if a user account provided by the user exists or not
        /// </summary>
        /// <param name="userQ"></param>
        /// <returns>AppUserAuth</returns>
        protected async Task<AppUserAuth> ValidateUser (AuthenticationQuery userQ) {

            AppUserAuth ret = new AppUserAuth ();
            ApplicationUser authUser = null;

            authUser = await _Mediator.Send (userQ);

            if (authUser != null) {
                ret = BuildUserAuthObject (authUser);
            }
            return ret;

        }

        /// <summary>
        /// builds jwt token that will be used to identify a seesion that will be used by a user
        /// </summary>
        /// <param name="authUser"></param>
        /// <returns>tokenString</returns>
        protected string BuildJwtToken (AppUserAuth authUser) {
            SymmetricSecurityKey key = new SymmetricSecurityKey (
                Encoding.UTF8.GetBytes (_settings.Key));

            List<Claim> jwtClaims = new List<Claim> ();

            jwtClaims.Add (new Claim (JwtRegisteredClaimNames.Sub, authUser.UserName));
            jwtClaims.Add (new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()));

            jwtClaims.Add (new Claim ("isAuthenticated", authUser.IsAuthenticated.ToString ().ToLower ()));

            foreach (var claim in authUser.Claims) {
                jwtClaims.Add (new Claim (claim.ClaimType, claim.ClaimValue));
            }

            var token = new JwtSecurityToken (
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: jwtClaims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes (_settings.MinutesToExpiration),
                signingCredentials: new SigningCredentials (key, SecurityAlgorithms.HmacSha256)

            );

            return new JwtSecurityTokenHandler ().WriteToken (token);
        }

        /// <summary>
        /// builds user authentication object that will be returned on successfull log in
        /// </summary>
        /// <param name="authUser"></param>
        /// <returns>AppUserAuth</returns>
        protected AppUserAuth BuildUserAuthObject (ApplicationUser authUser) {
            AppUserAuth ret = new AppUserAuth ();

            List<RoleClaims> claims = new List<RoleClaims> ();

            ret.UserName = authUser.UserName;
            ret.IsAuthenticated = true;

            ret.Claims = GetUserClaims (authUser);

            ret.BearerToken = BuildJwtToken (ret);

            return ret;
        }

        /// <summary>
        /// returned all the claims a user has
        /// </summary>
        /// <param name="authUser"></param>
        /// <returns>AspNetUserClaims</returns>
        protected List<RoleClaims> GetUserClaims (ApplicationUser authUser) {

            List<RoleClaims> list = new List<RoleClaims> ();

            try {

                list = (from a in _database.UserRoles.Where (a => a.UserId == authUser.Id) join role in _database.Roles on a.RoleId equals role.Id join roleClaim in _database.RoleClaims on role.Id equals roleClaim.RoleId select new RoleClaims {
                        ClaimType = roleClaim.ClaimType,
                            ClaimValue = roleClaim.ClaimValue
                    })

                    .ToList ();

            } catch (Exception ex) {
                throw new Exception ("Exception trying toretrive user claims", ex);
            }

            return list;
        }

    }
}