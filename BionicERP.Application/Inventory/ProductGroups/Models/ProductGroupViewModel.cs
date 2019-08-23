using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.ProductGroups.Models {
    public class ProductGroupViewModel {

        public uint Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public uint? ParentGroup { get; set; }
        public string Parent { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<ProductGroup, ProductGroupViewModel>> Projection {
            get {
                return group => new ProductGroupViewModel () {
                    Id = group.Id,
                    GroupName = group.GroupName,
                    Description = group.Description,
                    ParentGroup = group.ParentGroup,
                    Parent = group.ParentGroupNavigation.GroupName,
                    DateAdded = group.DateAdded,
                    DateUpdated = group.DateUpdated

                };
            }
        }
    }
}