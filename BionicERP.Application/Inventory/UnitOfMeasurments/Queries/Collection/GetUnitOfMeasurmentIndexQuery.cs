using System.Collections.Generic;
using BionicERP.Application.Inventory.UnitOfMeasurments.Models;
using MediatR;
/*
 * @CreateTime: Aug 23, 2019 3:07 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 3:08 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Inventory.UnitOfMeasurments.Queries {
    public class GetUnitOfMeasurmentIndexQuery : IRequest<IEnumerable<UnitOfMeasurmentIndexModel>> {
        private string UnitName { get; set; } = "";
        public string Name {
            get {
                return UnitName;
            }
            set {
                UnitName = (value == null) ? "" : value;
            }
        }
    }
}