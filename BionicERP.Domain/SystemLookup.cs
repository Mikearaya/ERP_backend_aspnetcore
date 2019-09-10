/*
 * @CreateTime: Sep 10, 2019 11:51 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 10, 2019 11:51 AM 
 * @Description: Modify Here, Please  
 */
using System;

namespace BionicERP.Domain {
    public class SystemLookup {

        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public sbyte? IsSystem { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}