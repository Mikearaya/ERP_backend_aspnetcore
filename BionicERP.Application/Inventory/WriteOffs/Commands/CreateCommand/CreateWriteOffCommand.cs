/*
 * @CreateTime: Sep 7, 2019 12:55 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:02 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Inventory.WriteOffs.Models;
using MediatR;

namespace BionicERP.Application.Inventory.WriteOffs.Commands {
    public class CreateWriteOffCommand : IRequest<uint> {
        public CreateWriteOffCommand () {
            WriteOffDetail = new List<WriteOffItem> ();
        }
        public uint ItemId { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }

        public IEnumerable<WriteOffItem> WriteOffDetail { get; set; }
    }
}