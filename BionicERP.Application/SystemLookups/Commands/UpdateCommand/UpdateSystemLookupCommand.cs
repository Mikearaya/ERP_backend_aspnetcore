/*
 * @CreateTime: Sep 10, 2019 12:08 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:09 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.SystemLookups.Models;
using MediatR;

namespace BionicERP.Application.SystemLookups.Commands {
    public class UpdateSystemLookupCommand : IRequest {
        public IEnumerable<NewSystemLookupModel> Lookups { get; set; } = new List<NewSystemLookupModel> ();
    }
}