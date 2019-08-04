/*
 * @CreateTime: Apr 24, 2019 5:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 9:01 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicERP.Application.Exceptions {
    public class DeleteFailureException : Exception {
        public DeleteFailureException (string name, object key, string message) : base ($"Deletion of entity \"{name}\" ({key}) failed. {message}") { }
    }
}