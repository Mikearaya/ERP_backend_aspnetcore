/*
 * @CreateTime: Aug 5, 2019 8:41 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 8:49 PM
 * @Description: Modify Here, Please  
 */
using MediatR;

namespace BionicERP.Application.Inventory.Items.Commands {
    public class CreateItemCommand : IRequest<uint> {

        public string Code { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }
        public float UnitCost { get; set; }
        public string Photo { get; set; }
        public float? MinimumQuantity { get; set; }
        public uint GroupId { get; set; }
        public sbyte? IsProcured { get; set; }
        public sbyte? IsInventory { get; set; }
        public float? Price { get; set; }
        public uint? ShelfLife { get; set; }
        public uint PrimaryUomId { get; set; }
        public uint DefaultStorageId { get; set; }

    }
}