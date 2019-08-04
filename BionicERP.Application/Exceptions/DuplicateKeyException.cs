/*
 * @CreateTime: Feb 7, 2019 2:45 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 9:01 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicERP.Application.Exceptions {
    public class DuplicateKeyException : Exception {
        public DuplicateKeyException () { }

        public DuplicateKeyException (string columnName, string id) : base ($" {columnName} id ({id}) already used ") { }

    }
}