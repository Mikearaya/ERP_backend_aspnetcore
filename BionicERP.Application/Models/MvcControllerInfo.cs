/*
 * @CreateTime: Jan 3, 2019 2:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 22, 2019 1:19 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;

namespace BionicShipment.Application.Models {
    public class MvcControllerInfo {
        public string id => $"{areaName}{name}";
        public string name { get; set; }
        public string displayName { get; set; }
        public string areaName { get; set; }
        public IEnumerable<MvcActionInfo> Actions { get; set; }

        public bool Checked { get; set; }
    }
}