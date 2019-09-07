/*
 * @CreateTime: Sep 7, 2019 1:24 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:25 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.WriteOffs.Models {
    public class WriteOffViewModel {
        private float _quantity = 0;
        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public uint ItemGroupId { get; set; }
        public string Item { get; set; }
        public string Uom { get; set; }
        public string ItemGroup { get; set; }
        public string Status { get; set; }
        public float Quantity { get; set; }

        public float TotalCost { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        private void calculateTotalCost () {

        }

        public static Expression<Func<WriteOff, WriteOffViewModel>> Projection {
            get {
                return writeoff => new WriteOffViewModel () {
                    Id = writeoff.Id,
                    ItemId = writeoff.ItemId,
                    Item = writeoff.Item.Name,
                    ItemGroup = writeoff.Item.Group.GroupName,
                    Uom = writeoff.Item.PrimaryUom.Abrivation,
                    ItemGroupId = writeoff.Item.GroupId,
                    Status = writeoff.Status,
                    Quantity = writeoff.WriteOffDetail.GroupBy (wd => wd.WriteOff).Sum (d => d.Sum (dq => dq.Quantity)),
                    TotalCost = writeoff.WriteOffDetail.GroupBy (wd => wd.WriteOff).Sum (d => d.Sum (dq => dq.Quantity * dq.BatchStorage.Batch.UnitCost)),
                    Type = writeoff.Type,
                    Note = writeoff.Note,
                    DateAdded = writeoff.DateAdded,
                    DateUpdated = writeoff.DateUpdated,
                };
            }
        }

        public static WriteOffViewModel create (WriteOff writeoff) {
            return Projection.Compile ().Invoke (writeoff);
        }
    }
}