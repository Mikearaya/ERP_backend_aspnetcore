/*
 * @CreateTime: Aug 5, 2019 9:36 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:37 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseTerms.Commands {
    public class CreatePurchaseTermCommand : IRequest<uint> {
        public uint VendorId { get; set; }
        public uint ItemId { get; set; }
        public string VendorProductId { get; set; }
        public uint? Priority { get; set; }
        public uint? Leadtime { get; set; }
        public uint? MinimumQuantity { get; set; }
        public float UnitPrice { get; set; }
    }
}