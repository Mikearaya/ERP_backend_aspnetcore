/*
 * @CreateTime: Aug 24, 2019 10:29 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 10:31 AM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.UnitOfMeasurments.Models;
using MediatR;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Queries {
    public class GetUnitOfMeasurmentByIdQuery : IRequest<UnitOfMeasurmentViewModel> {
        public uint Id { get; set; }
    }
}