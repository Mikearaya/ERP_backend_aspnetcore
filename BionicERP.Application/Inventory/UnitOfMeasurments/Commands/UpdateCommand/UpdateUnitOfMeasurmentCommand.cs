/*
 * @CreateTime: Aug 23, 2019 2:50 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 23, 2019 2:50 PM 
 * @Description: Modify Here, Please  
 */
/*
 * @CreateTime: Aug 23, 2019 2:50 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 23, 2019 2:50 PM 
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Commands {
    public class UpdateUnitOfMeasurmentCommand : IRequest {

        public uint Id { get; set; }
        public string Abrivation { get; set; }
        public string Name { get; set; }
        public sbyte? Active { get; set; }
    }
}