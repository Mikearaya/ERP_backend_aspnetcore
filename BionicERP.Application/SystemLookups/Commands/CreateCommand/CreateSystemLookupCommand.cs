using System.Collections.Generic;
using BionicERP.Application.SystemLookups.Models;
/*
 * @CreateTime: Sep 10, 2019 11:55 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:09 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.SystemLookups.Commands {
    public class CreateSystemLookupCommand : IRequest {
        public IEnumerable<NewSystemLookupModel> Lookups = new List<NewSystemLookupModel> ();
    }
}