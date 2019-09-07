/*
 * @CreateTime: Sep 7, 2019 1:26 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:31 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.WriteOffs.Models {
    public class WriteOffDetailViewModel {

        public uint Id { get; set; }
        public uint ItemId { get; set; }
        public uint ItemGroupId { get; set; }
        public string Item { get; set; }
        public string Uom { get; set; }
        public string ItemGroup { get; set; }
        public string Status { get; set; }
        public float Quantity { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public IEnumerable<WriteOffItemView> WriteOffDetail { get; set; }

        public static Expression<Func<WriteOff, WriteOffDetailViewModel>> Projection {
            get {
                return writeoff => new WriteOffDetailViewModel () {
                    Id = writeoff.Id,
                    ItemId = writeoff.ItemId,
                    Item = writeoff.Item.Name,
                    ItemGroup = writeoff.Item.Group.GroupName,
                    Uom = writeoff.Item.PrimaryUom.Abrivation,
                    ItemGroupId = writeoff.Item.GroupId,
                    Status = writeoff.Status,
                    Type = writeoff.Type,
                    Note = writeoff.Note,
                    DateAdded = writeoff.DateAdded,
                    DateUpdated = writeoff.DateUpdated,
                    WriteOffDetail = writeoff.WriteOffDetail.AsQueryable ()
                    .Select (WriteOffItemView.Projection)

                };
            }
        }

    }
}