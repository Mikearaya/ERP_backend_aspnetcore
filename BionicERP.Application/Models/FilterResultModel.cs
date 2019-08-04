/*
 * @CreateTime: Jul 25, 2019 3:31 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Jul 25, 2019 3:31 PM 
 * @Description: Modify Here, Please  
 */

using System.Collections.Generic;

namespace BionicShipment.Application.Models {
    public class FilterResultModel<T> {
        public IEnumerable<T> Items;
        public int Count;
    }
}