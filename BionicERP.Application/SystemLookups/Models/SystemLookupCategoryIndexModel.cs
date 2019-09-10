/*
 * @CreateTime: Sep 10, 2019 12:30 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:31 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain;

namespace BionicERP.Application.SystemLookups.Models {
    public class SystemLookupCategoryIndexModel {
        public string Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<SystemLookup, SystemLookupCategoryIndexModel>> Project {
            get {
                return lookup => new SystemLookupCategoryIndexModel () {
                    Id = lookup.Value,
                    Name = lookup.Value,
                };
            }
        }
    }
}