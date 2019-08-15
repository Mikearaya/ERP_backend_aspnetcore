/*
 * @CreateTime: Aug 15, 2019 7:20 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 15, 2019 8:00 PM
 * @Description: Modify Here, Please  
 */
using System;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseOrderPayments.Commands {
    public class CreatePurchaseOrderPaymentCommand : IRequest<uint> {
        public double Amount { get; set; }
        public uint? PurchaseOrderId { get; set; }
        public int? CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}