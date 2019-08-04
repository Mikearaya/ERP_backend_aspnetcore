/*
 * @CreateTime: Oct 2, 2018 8:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 8:51 PM
 * @Description: Modify Here, Please 
 */
using System;
using BionicERP.Domain;
using BionicERP.Domain.Inventory;

namespace BionicERP.Domain.Production {
    public class FinishedProduct {
        public uint Id { get; set; }
        public uint OrderId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint SubmittedBy { get; set; }
        public uint RecievedBy { get; set; }
        public int? Quantity { get; set; }

        public virtual ProductionOrderList Order { get; set; }
        public virtual Employee RecievedByNavigation { get; set; }
        public virtual Employee SubmittedByNavigation { get; set; }
        public virtual BookedStockItems BookedStockItems { get; set; }

    }
}