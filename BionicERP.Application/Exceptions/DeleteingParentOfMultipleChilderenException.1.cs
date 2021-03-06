﻿/*
 * @CreateTime: Apr 24, 2019 5:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 9:01 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicERP.Application.Exceptions {
    public class DeleteingParentOfMultipleChilderenException : Exception {

        public DeleteingParentOfMultipleChilderenException () { }
        public DeleteingParentOfMultipleChilderenException (string name, object key) : base ($"unable to  delete {name} with id ({key}) its related with multiple child records") { }
    }
}