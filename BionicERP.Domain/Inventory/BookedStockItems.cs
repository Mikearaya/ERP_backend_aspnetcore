/*
 * @CreateTime: Oct 22, 2018 10:40 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 8:52 PM
 * @Description: Modify Here, Please 
 */
using System;
using BionicERP.Domain;
using BionicERP.Domain.CRM;
using BionicERP.Domain.Production;

namespace BionicERP.Domain.Inventory {

    public class BookedStockItems {
        public uint Id { get; set; }
        public uint StockId { get; set; }
        public sbyte? Canceled { get; set; } = 0;
        public uint BookedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public uint BookedFor { get; set; }
        public string Note { get; set; }

        public Employee BookedByNavigation { get; set; }
        public CustomerOrderItem BookedForNavigation { get; set; }
        public FinishedProduct Stock { get; set; }
    }
}