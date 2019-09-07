/*
 * @CreateTime: Sep 7, 2019 3:43 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 3:50 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Inventory.Shipments.Models {
    public class ShipmentItem {
        public uint? Id { get; set; }
        public uint BookedQuantity { get; set; }
        public uint LotBookingId { get; set; }
    }
}