/*
 * @CreateTime: Sep 7, 2019 3:42 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 3:44 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using BionicERP.Application.Inventory.Shipments.Models;
using MediatR;

namespace BionicERP.Application.Inventory.Shipments.Commands {
    public class CreateShipmentCommand : IRequest<uint> {
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public IEnumerable<ShipmentItem> ShipmentDetail { get; set; } = new List<ShipmentItem> ();
    }
}