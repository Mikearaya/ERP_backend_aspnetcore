/*
 * @CreateTime: Sep 10, 2019 12:31 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:32 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.SystemLookups.Models;
using MediatR;

namespace BionicERP.Application.SystemLookups.Queries {
    public class GetSystemLookupByIdQuery : IRequest<SystemLookupViewModel> {
        public int Id { get; set; }
    }
}