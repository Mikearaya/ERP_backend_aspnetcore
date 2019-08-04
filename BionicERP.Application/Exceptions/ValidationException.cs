/*
 * @CreateTime: Apr 24, 2019 5:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 22, 2019 1:14 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace BionicERP.Application.Exceptions {
    public class ValidationException : Exception {
        public ValidationException () : base ("One or more validation failures have occurred.") {
            Failures = new Dictionary<string, string[]> ();
        }

        public ValidationException (List<ValidationFailure> failures) : this () {
            var propertyNames = failures
                .Select (e => e.PropertyName)
                .Distinct ();

            foreach (var propertyName in propertyNames) {
                var propertyFailures = failures
                    .Where (e => e.PropertyName == propertyName)
                    .Select (e => e.ErrorMessage)
                    .ToArray ();

                Failures.Add (propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}