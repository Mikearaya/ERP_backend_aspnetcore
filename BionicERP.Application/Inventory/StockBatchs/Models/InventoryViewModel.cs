/*
 * @CreateTime: Jan 6, 2019 12:58 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 6, 2019 6:05 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Application.Inventory.Items.Models;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.StockBatchs.Models {
    public class InventoryView {
        private float _quantity = 0;
        public uint ItemId { get; set; }
        public string ItemCode { get; set; }
        public string Item { get; set; }
        public uint ItemGroupId { get; set; }
        public string ItemGroup { get; set; }
        public float Quantity {
            get {
                return _quantity;
            }
            set {
                _quantity = value;
            }
        }
        public uint WriteOffId { get; set; }
        public float TotalCost { get; set; }
        public float AverageUnitCost {
            get {
                return (Quantity == 0) ? 0 : TotalCost / Quantity;
            }

        }

        public float TotalWriteOffs { get; set; }
        public string Uom { get; set; }
        public uint UomId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<IGrouping<Item, ItemLotJoin>, InventoryView>> Projection {

            get {
                return inventory => new InventoryView () {
                    ItemId = inventory.Key.Id,
                    Item = inventory.Key.Name,
                    ItemCode = inventory.Key.Code,
                    Uom = inventory.Select (i => i.uom).FirstOrDefault (),
                    UomId = inventory.Key.PrimaryUomId,
                    ItemGroupId = inventory.Key.GroupId,
                    ItemGroup = inventory.Select (i => i.group).FirstOrDefault (),
                    DateAdded = inventory.Key.DateAdded,
                    DateUpdated = inventory.Key.DateUpdate,
                    Quantity = inventory.Sum (s => s.Lot.Where (stat => stat.Batch.Status.ToUpper () == "RECIEVED").Sum (q => q.Quantity)),
                    TotalCost = inventory.Sum (s => s.Lot.Where (stat => stat.Batch.Status.ToUpper () == "RECIEVED").Sum (q => q.Quantity * q.Batch.UnitCost))

                };
            }
        }

    }
}