/*
 * @CreateTime: Sep 10, 2019 12:29 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Sep 10, 2019 12:29 PM 
 * @Description: Modify Here, Please  
 */
using System;
using System.Linq.Expressions;
using BionicERP.Domain;

namespace BionicERP.Application.SystemLookups.Models {
    public class SystemLookupIndexModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public static Expression<Func<SystemLookup, SystemLookupIndexModel>> Projection {
            get {
                return lookup => new SystemLookupIndexModel () {
                    Id = lookup.Id,
                    Name = lookup.Value,
                    Type = lookup.Type
                };
            }
        }

    }
}