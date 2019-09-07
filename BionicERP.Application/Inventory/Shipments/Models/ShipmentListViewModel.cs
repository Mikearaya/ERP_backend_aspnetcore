/*
 * @CreateTime: Sep 7, 2019 4:02 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 4:03 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.Shipments.Models {
    public class ShipmentListViewModel {
        public uint Id { get; set; }
        public string Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<Shipment, ShipmentListViewModel>> Projection {
            get {
                return shipment => new ShipmentListViewModel () {
                    Id = shipment.Id,
                    Status = shipment.Status,
                    DeliveryDate = shipment.DeliveryDate,
                    DateAdded = shipment.DateAdded,
                    DateUpdated = shipment.DateUpdated
                };
            }
        }
    }
}