/*
 * @CreateTime: Sep 10, 2019 9:15 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 10, 2019 9:15 AM 
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Users.Models;
using MediatR;

namespace BionicERP.Application.Users.Queries {
    public class GetUserIndexQuery : IRequest<IEnumerable<UserIndexModel>> {

        private string filter { get; set; } = "";
        public string SearchString {
            get {
                return filter;
            }
            set {
                filter = (value == null) ? "" : value;
            }
        }

    }
}