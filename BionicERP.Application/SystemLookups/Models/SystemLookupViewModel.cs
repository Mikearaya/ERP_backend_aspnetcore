/*
 * @CreateTime: Sep 10, 2019 12:26 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:28 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain;

namespace BionicERP.Application.SystemLookups.Models {
    public class SystemLookupViewModel {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public static Expression<Func<SystemLookup, SystemLookupViewModel>> Projection {
            get {
                return lookup => new SystemLookupViewModel () {
                    Id = lookup.Id,
                    Type = lookup.Type,
                    Value = lookup.Value,
                    DateAdded = lookup.DateAdded,
                    DateUpdated = lookup.DateUpdated
                };
            }
        }
    }
}