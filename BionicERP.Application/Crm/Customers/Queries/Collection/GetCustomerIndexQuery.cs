/*
 * @CreateTime: Sep 7, 2019 5:43 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:45 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Crm.Customers.Models;
using MediatR;

namespace BionicERP.Application.Crm.Customers.Queries {
    public class GetCustomerIndexQuery : IRequest<IEnumerable<CustomerIndexModel>> {

        private string _Name { get; set; } = "";

        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = (value == null) ? "" : value;
            }
        }

    }
}