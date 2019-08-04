/*
 * @CreateTime: Jan 1, 2019 9:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 9:01 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicERP.Application.Exceptions {
    public class QuantityGreaterThanAvailableException : Exception {
        public QuantityGreaterThanAvailableException (
            string type,
            double quantity,
            double available) : base ($" {type} specified quantity {quantity} is greater than available   Quantity ({available}).") { }
    }
}