/*
 * @CreateTime: Aug 5, 2019 9:39 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 9:43 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Procurment;
using MediatR;

namespace BionicERP.Application.Procurment.PurchaseTerms.Commands {
    public class CreatePurchaseTermCommandHandler : IRequestHandler<CreatePurchaseTermCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public CreatePurchaseTermCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreatePurchaseTermCommand, VendorPurchaseTerm> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreatePurchaseTermCommand request, CancellationToken cancellationToken) {

            VendorPurchaseTerm purchaseTerm = _Mapper.Map<CreatePurchaseTermCommand, VendorPurchaseTerm> (request);

            await _database.VendorPurchaseTerm.AddAsync (purchaseTerm);
            await _database.SaveAsync ();

            return purchaseTerm.Id;
        }
    }
}