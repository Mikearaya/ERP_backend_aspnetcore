/*
 * @CreateTime: Apr 26, 2019 10:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 22, 2019 3:34 PM
 * @Description: Modify Here, Please 
 */
using System.ComponentModel.DataAnnotations;
using BionicERP.Domain.Identity;
using MediatR;

namespace BionicERP.Application.Models {
    public class AuthenticationQuery : IRequest<ApplicationUser> {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}