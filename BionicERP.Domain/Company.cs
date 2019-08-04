/*
 * @CreateTime: Oct 2, 2018 8:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 8:50 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicERP.Domain {
    public class Company {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Tin { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string Location { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}