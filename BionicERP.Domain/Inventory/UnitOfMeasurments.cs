/*
 * @CreateTime: Dec 3, 2018 8:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 18, 2019 8:18 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicERP.Domain.Production;

namespace BionicERP.Domain.Inventory {
    public class UnitOfMeasurment {
        public UnitOfMeasurment () {
            BomItems = new HashSet<BomItems> ();
            Item = new HashSet<Item> ();
        }

        public uint Id { get; set; }
        public string Abrivation { get; set; }
        public string Name { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public sbyte? Active { get; set; }

        public virtual ICollection<BomItems> BomItems { get; set; }
        public virtual ICollection<Item> Item { get; set; }

    }
}