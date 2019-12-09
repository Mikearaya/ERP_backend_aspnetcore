/*
 * @CreateTime: Dec 9, 2019 6:50 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2019 6:54 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class DeleteCustomerSocialMediaCommandHandler : IRequestHandler<DeleteCustomerSocialMediaCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;

        public DeleteCustomerSocialMediaCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteCustomerSocialMediaCommand request, CancellationToken cancellationToken) {
            SocialMedia customerSocial = await _database.SocialMedia
                .FirstOrDefaultAsync (c => c.Id == request.Id && c.ClientId == request.CustomerId);

            if (customerSocial == null) {
                throw new NotFoundException ("Customer Social", request.Id);
            }

            _database.SocialMedia.Remove (customerSocial);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}