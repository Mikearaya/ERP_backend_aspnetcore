using System.Collections.Generic;
using BionicERP.Application.Crm.CustomerOrders.Models;
using MediatR;
/*
 * @CreateTime: Sep 8, 2019 5:07 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:09 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Crm.CustomerOrders.Queries {
    public class GetCustomerOrderIndexQuery : IRequest<IEnumerable<CustomerOrderIndex>> {
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