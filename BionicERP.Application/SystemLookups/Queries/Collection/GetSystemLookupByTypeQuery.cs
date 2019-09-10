/*
 * @CreateTime: May 6, 2019 11:45 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:43 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicERP.Application.SystemLookups.Models;
using BionicERP.Commons.QueryHelpers;
using MediatR;

namespace BionicERP.Application.SystemLookups.Queries {
    public class GetSystemLookupByTypeQuery : ApiQueryString, IRequest<IEnumerable<SystemLookupIndexModel>> {
        private string Term { get; set; } = "";

        public string Type { get; set; }
        public string SearchString {
            get {
                return Term;
            }
            set {
                Term = (value == null) ? "" : value;
            }
        }
    }
}