/*
 * @CreateTime: Sep 7, 2019 1:35 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:36 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.WriteOffs.Models;
using MediatR;

namespace BionicERP.Application.Inventory.WriteOffs.Queries {
    public class GetWriteOffByIdQuery : IRequest<WriteOffDetailViewModel> {
        public uint Id { get; set; }
    }
}