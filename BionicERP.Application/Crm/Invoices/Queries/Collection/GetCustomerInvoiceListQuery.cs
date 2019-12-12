using System.Collections.Generic;
/*
 * @CreateTime: Dec 12, 2019 4:04 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 12, 2019 4:37 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Crm.InvoicePayment.Models;
using MediatR;

namespace BionicERP.Application.Crm.Invoices.Queries {
    public class GetCustomerInvoiceListQuery : IRequest<IEnumerable<InvoicePaymentStatusView>> {
        public string query { get; set; } = "";

    }
}