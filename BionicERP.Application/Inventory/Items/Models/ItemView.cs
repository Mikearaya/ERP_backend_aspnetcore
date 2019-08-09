/*
 * @CreateTime: Sep 9, 2018 6:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:02 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicInventory.Application.Stocks.Items.Models {
    public class ItemView {
        public uint Id;
        public string Code;
        public string Name;
        public float? MinimumQuantity;
        public string Description;
        public float? Weight;
        public float UnitCost;
        public float? Price;
        public string StoringUoM;
        public string Photo;

        public string DefaultStorage { get; set; }
        public uint DefaultStorageId { get; set; }

        public bool IsInventoryItem { get; set; }
        public bool IsProcured { get; set; }
        public uint PrimaryUomId { get; set; }
        public string PrimaryUom { get; set; }
        public uint? ShelfLife { get; set; }
        public uint GroupId { get; set; }
        public string Group { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateAdded { get; set; }

        public static Expression<Func<Item, ItemView>> Projection {

            get {
                return item => new ItemView () {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    MinimumQuantity = item.MinimumQuantity,
                    Weight = item.Weight,
                    UnitCost = item.UnitCost,
                    Price = item.Price,
                    PrimaryUom = item.PrimaryUom.Abrivation,
                    PrimaryUomId = item.PrimaryUomId,
                    Photo = item.Photo,
                    DefaultStorage = item.DefaultStorage.Name,
                    DefaultStorageId = item.DefaultStorageId,
                    IsInventoryItem = (item.IsInventory == 1) ? true : false,
                    IsProcured = (item.IsProcured == 1) ? true : false,
                    ShelfLife = item.ShelfLife,
                    GroupId = item.GroupId,
                    Group = item.Group.GroupName,
                    DateAdded = item.DateAdded,
                    DateUpdated = item.DateUpdate
                };
            }
        }
    }
}