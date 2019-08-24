/*
 * @CreateTime: Aug 23, 2019 3:04 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 23, 2019 3:07 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain.Inventory;

namespace BionicERP.Application.Inventory.UnitOfMeasurments.Models {
    public class UnitOfMeasurmentIndexModel {

        public uint Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<UnitOfMeasurment, UnitOfMeasurmentIndexModel>> Projection {
            get {
                return unit => new UnitOfMeasurmentIndexModel () {
                    Id = unit.Id,
                    Name = $"{unit.Name} ({unit.Abrivation})"
                };
            }
        }
    }
}