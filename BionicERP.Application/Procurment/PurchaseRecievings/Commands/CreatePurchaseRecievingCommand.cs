/*
 * @CreateTime: Aug 15, 2019 2:22 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 2:31 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Procurment.PurchaseRecievings.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseRecievings.Commands {
    public class CreatePurchaseRecievingCommand : IRequest<uint> {
        public uint PurchaseOrderId { get; set; }

        public IEnumerable<PurchaseRecievingItem> PurchaseOrderItems { get; set; } = new List<PurchaseRecievingItem> ();
    }
}