/*
 * @CreateTime: Sep 10, 2019 9:03 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:04 AM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Users.Commands {
    public class DeleteUserCommand : IRequest {
        public string Id { get; set; }
    }
}