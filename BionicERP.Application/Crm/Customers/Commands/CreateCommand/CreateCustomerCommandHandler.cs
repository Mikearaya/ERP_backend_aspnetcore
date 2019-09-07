/*
 * @CreateTime: Sep 7, 2019 4:56 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:00 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Crm.Customers.Models;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;

namespace BionicERP.Application.Crm.Customers.Commands {
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public CreateCustomerCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateCustomerCommand, Customer> ();
                x.CreateMap<CustomerAddressModel, Address> ();
                x.CreateMap<CustomerPhoneNumberModel, PhoneNumber> ();
                x.CreateMap<CustomerSocialMediaModel, SocialMedia> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreateCustomerCommand request, CancellationToken cancellationToken) {

            Customer customer = _Mapper.Map<CreateCustomerCommand, Customer> (request);

            await _database.Customer.AddAsync (customer);
            await _database.SaveAsync ();

            return customer.Id;
        }
    }
}