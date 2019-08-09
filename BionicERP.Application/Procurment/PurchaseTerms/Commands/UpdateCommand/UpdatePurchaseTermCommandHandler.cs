/*
 * @CreateTime: Aug 5, 2019 9:45 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:49 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Procurment;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseTerms.Commands {
    public class UpdatePurchaseTermCommandHandler : IRequestHandler<UpdatePurchaseTermCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public UpdatePurchaseTermCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdatePurchaseTermCommand, VendorPurchaseTerm> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdatePurchaseTermCommand request, CancellationToken cancellationToken) {
            var updatedTerm = await _database.VendorPurchaseTerm.FindAsync (request.Id);

            if (updatedTerm == null) {
                throw new NotFoundException (nameof (VendorPurchaseTerm), request.Id);
            }

            _Mapper.Map (request, updatedTerm);

            _database.VendorPurchaseTerm.Update (updatedTerm);

            await _database.SaveAsync ();

            return Unit.Value;

        }
    }
}