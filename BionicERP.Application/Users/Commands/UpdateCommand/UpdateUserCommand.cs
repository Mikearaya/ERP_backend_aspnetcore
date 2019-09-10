/*
 * @CreateTime: Sep 10, 2019 8:58 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 8:59 AM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Users.Commands {
    public class UpdateUserCommand : IRequest {

        public string Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string RoleId { get; set; }
    }
}