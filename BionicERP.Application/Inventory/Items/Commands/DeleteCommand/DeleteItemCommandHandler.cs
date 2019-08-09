/*
 * @CreateTime: Aug 5, 2019 8:55 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 8:58 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.Items.Commands {
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteItemCommandHandler (IBionicERPDatabaseService database) {
            _database = database;

        }

        public async Task<Unit> Handle (DeleteItemCommand request, CancellationToken cancellationToken) {
            var item = await _database.Item.FindAsync (request.Id);

            if (item == null) {
                throw new NotFoundException (nameof (Item), request.Id);
            }

            _database.Item.Remove (item);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}