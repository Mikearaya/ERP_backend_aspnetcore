/*
 * @CreateTime: Sep 10, 2019 9:24 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:26 AM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Users.Models;
using MediatR;

namespace BionicERP.Application.Users.Queries {
    public class GetUserByIdQuery : IRequest<UserViewModel> {
        public string Id { get; set; }
    }
}