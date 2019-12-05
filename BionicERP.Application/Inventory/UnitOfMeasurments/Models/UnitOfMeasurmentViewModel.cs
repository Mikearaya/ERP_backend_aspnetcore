/*
 * @CreateTime: Aug 23, 2019 2:41 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 2:42 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Models {
    public class UnitOfMeasurmentViewModel {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Abrevation { get; set; }

        public Boolean Active { get; set; }

        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<UnitOfMeasurment, UnitOfMeasurmentViewModel>> Projection {
            get {
                return uom => new UnitOfMeasurmentViewModel {
                    Id = uom.Id,
                    Name = uom.Name,
                    Abrevation = uom.Abrivation,
                    Active = (uom.Active == 1) ? true : false,
                    DateAdded = uom.DateAdded,
                    DateUpdated = uom.DateUpdated

                };
            }
        }

        public static UnitOfMeasurmentViewModel Create (UnitOfMeasurment uom) {
            return Projection.Compile ().Invoke (uom);
        }
    }
}