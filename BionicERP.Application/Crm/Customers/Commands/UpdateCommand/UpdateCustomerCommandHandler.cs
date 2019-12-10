/*
 * @CreateTime: Sep 7, 2019 5:04 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:07 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Crm.Customers.Models;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private readonly IMapper _Mapper;

        public UpdateCustomerCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateCustomerCommand, Customer> ();
                x.CreateMap<CustomerSocialMediaModel, SocialMedia> ();
                x.CreateMap<CustomerAddressModel, Address> ();
                x.CreateMap<CustomerPhoneNumberModel, PhoneNumber> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateCustomerCommand request, CancellationToken cancellationToken) {
            Customer customer = await _database.Customer.Include (x => x.PhoneNumber)
                .Include (x => x.SocialMedia)
                .Include (x => x.Address)
                .AsNoTracking ()
                .FirstOrDefaultAsync (x => x.Id == request.Id);

            if (customer == null) {
                throw new NotFoundException ("Customer", request.Id);
            }
            _Mapper.Map (request, customer);

            _database.Customer.Update (customer);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}