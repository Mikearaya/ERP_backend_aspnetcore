/*
 * @CreateTime: Sep 8, 2019 4:27 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 4:35 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Crm.CustomerOrders.Models;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;

namespace BionicERP.Application.Crm.CustomerOrders.Commands {
    public class CreateCustomerOrderCommandHandler : IRequestHandler<CreateCustomerOrderCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public CreateCustomerOrderCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateCustomerOrderCommand, CustomerOrder> ();
                x.CreateMap<CustomerOrderItemModel, CustomerOrderItem> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreateCustomerOrderCommand request, CancellationToken cancellationToken) {
            CustomerOrder customerOrder = _Mapper.Map<CreateCustomerOrderCommand, CustomerOrder> (request);

            await _database.CustomerOrder.AddAsync (customerOrder);
            await _database.SaveAsync ();

            return customerOrder.Id;
        }
    }
}