/*
 * @CreateTime: Dec 12, 2019 1:35 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 1:44 PM
 * @Description: Modify Here, Please  
 */
using System;
using MediatR;

namespace BionicERP.Application.Crm.InvoicePayment.Commands {
    public class CreateCustomerInvoicePaymentCommand : IRequest<uint> {

        public uint InvoiceNo { get; set; }
        public float Amount { get; set; }
        public string CheckNo { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }

    }
}