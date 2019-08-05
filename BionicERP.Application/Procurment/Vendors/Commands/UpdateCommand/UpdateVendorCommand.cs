/*
 * @CreateTime: Dec 23, 2018 10:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:08 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace BionicERP.Application.Procurment.Vendors.Commands {
    public class UpdateVendorCommand : IRequest {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TinNumber { get; set; }
        public uint? LeadTime { get; set; }
        public uint? PaymentPeriod { get; set; }

    }
}