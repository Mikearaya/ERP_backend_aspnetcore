/*
 * @CreateTime: Sep 10, 2019 12:15 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:22 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace BionicERP.Application.SystemLookups.Commands {
    public class DeleteSystemLookupCommandHandler : IRequestHandler<DeleteSystemLookupCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteSystemLookupCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteSystemLookupCommand request, CancellationToken cancellationToken) {

            List<ValidationFailure> validationFailures = new List<ValidationFailure> ();
            var lookup = await _database.SystemLookups
                .FindAsync (request.Id);

            if (lookup == null) {
                throw new NotFoundException ("System lookup", request.Id);
            }

            if (lookup.IsSystem == 1) {
                throw new Exception ("Can not delete system exception");
            }

            _database.SystemLookups.Remove (lookup);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}