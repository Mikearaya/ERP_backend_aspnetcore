/*
 * @CreateTime: Aug 15, 2019 7:34 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 7:35 PM
 * @Description: Modify Here, Please  
 */
using System;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Commands {
    public class UpdatePurchaseOrderPaymentCommand : IRequest {
        public uint Id { get; set; }
        public float Amount { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public string CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}