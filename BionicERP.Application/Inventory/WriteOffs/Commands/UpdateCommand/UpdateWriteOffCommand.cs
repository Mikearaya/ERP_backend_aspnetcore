/*
 * @CreateTime: Sep 7, 2019 1:08 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:11 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Inventory.WriteOffs.Models;
using MediatR;

namespace BionicERP.Application.Inventory.WriteOffs.Commands {
    public class UpdateWriteOffCommand : IRequest {
        public UpdateWriteOffCommand () {
            WriteOffDetail = new List<WriteOffItem> ();
        }
        public uint Id { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        public string Type { get; set; }
        public IEnumerable<WriteOffItem> WriteOffDetail { get; set; }

    }
}