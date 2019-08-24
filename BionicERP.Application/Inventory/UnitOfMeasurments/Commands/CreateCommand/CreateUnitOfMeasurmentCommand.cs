/*
 * @CreateTime: Aug 23, 2019 2:42 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:45 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Commands {
    public class CreateUnitOfMeasurmentCommand : IRequest<uint> {

        public string Abrivation { get; set; }
        public string Name { get; set; }
        public sbyte? Active { get; set; }

    }
}