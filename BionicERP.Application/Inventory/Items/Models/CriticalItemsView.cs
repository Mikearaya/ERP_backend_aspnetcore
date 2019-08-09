/*
 * @CreateTime: Oct 21, 2018 1:00 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:05 PM
 * @Description: Modify Here, Please 
 */

using System;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.Items.Models {

    public class CriticalItemsView {
        public uint Id { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }

        public float Required {
            get {
                if (AvailableQuantity < MinimumQuantity) {
                    return MinimumQuantity - AvailableQuantity;
                } else {
                    return 0;
                }
            }
        }
        public float MinimumQuantity { get; set; }

        public float AvailableQuantity { get; set; }
        public float ExpectedAvailableQuantity { get; set; }

        public string Uom { get; set; }
        public string Type { get; set; }

        public float InStock { get; set; }

        public static Expression<Func<IGrouping<Item, ItemLotJoin>, CriticalItemsView>> Projection {

            get {
                return critical => new CriticalItemsView () {
                    Id = critical.Key.Id,
                    ItemName = critical.Key.Name,
                    ItemCode = critical.Key.Code,
                    MinimumQuantity = (float) critical.Key.MinimumQuantity,
                    Type = (critical.Key.IsProcured == 1) ? "Purchased" : "Manufactured",
                    InStock = critical
                    .Sum (l =>
                    l.Lot.Where (i =>
                    i.Batch.Status.ToUpper () == "RECIEVED"
                    ).Sum (q => q.Quantity)),
                    ExpectedAvailableQuantity = critical
                    .Sum (l =>
                    l.Lot.Where (i =>
                    i.Batch.Status.ToUpper () == "PLANED"
                    ).Sum (q => q.Quantity)),
                    //   uom = critical.Key.PrimaryUom.Abrivation,
                    AvailableQuantity = critical
                    .Sum (l =>
                    l.Lot.Where (i =>
                    i.Batch.Status.ToUpper () == "RECIEVED"
                    ).Sum (q => q.Quantity) - l.Lot.Sum (b => b.BookedStockBatch.Sum (q => q.Quantity))),

                };
            }
        }

    }
}