/*
 * @CreateTime: Aug 17, 2019 11:06 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 17, 2019 11:08 AM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using BionicERP.Application.Procurment.PurchaseOrders.Models;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrders.Queries {
    public class GetPurchaseOrderIndexQuery : IRequest<IEnumerable<PurchaseOrderIndexModel>> {
        private string PurchaseOrderType { get; set; } = "All";
        public uint Id { get; set; }
        public string Type {
            get { return PurchaseOrderType; } set {
                PurchaseOrderType = value == null ? "All" : value;
            }
        }

    }
}