/*
 * @CreateTime: Sep 10, 2019 9:07 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 9:08 AM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Users.Commands {
    public class UpdateUserPasswordCommand : IRequest {
        public string Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmationPassword { get; set; }

    }
}