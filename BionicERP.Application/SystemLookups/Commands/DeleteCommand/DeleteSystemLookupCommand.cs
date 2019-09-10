/*
 * @CreateTime: Sep 10, 2019 12:14 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 10, 2019 12:14 PM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.SystemLookups.Commands {
    public class DeleteSystemLookupCommand : IRequest {
        public uint Id { get; set; }
    }
}