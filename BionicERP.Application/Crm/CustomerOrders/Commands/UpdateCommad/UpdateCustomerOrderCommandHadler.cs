using System.Linq;
/*
 * @CreateTime: Sep 8, 2019 4:38 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2019 5:16 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Crm.CustomerOrders.Models;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.CRM;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Crm.CustomerOrders.Commands {
    public class UpdateCustomerOrderCommandHadler : IRequestHandler<UpdateCustomerOrderCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;

        public UpdateCustomerOrderCommandHadler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateCustomerOrderCommand, CustomerOrder> ();
                x.CreateMap<CustomerOrderItemModel, CustomerOrderItem> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateCustomerOrderCommand request, CancellationToken cancellationToken) {
            CustomerOrder customerOrder = await _database.CustomerOrder
                .Include (c => c.CustomerOrderItem)
                .FirstOrDefaultAsync (x => x.Id == request.Id);

            if (customerOrder == null) {
                throw new NotFoundException ("Customer Order", request.Id);
            }

            foreach (var item in customerOrder.CustomerOrderItem) {
                var updated = request.CustomerOrderItem.FirstOrDefault (c => c.Id == item.Id);
                if (updated == null) {
                    _database.CustomerOrderItem.Remove (item);
                    continue;
                }
                item.Quantity = updated.Quantity;
                item.DueDate = updated.DueDate;

            }

            _Mapper.Map (request, customerOrder);

            _database.CustomerOrder.Update (customerOrder);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}