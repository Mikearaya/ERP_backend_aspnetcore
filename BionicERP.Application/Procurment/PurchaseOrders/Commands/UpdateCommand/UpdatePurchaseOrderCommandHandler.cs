using System;
/*
 * @CreateTime: Aug 9, 2019 2:21 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya 
 * @Last Modified Time: Aug 9, 2019 2:21 PM 
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.StockBatchs.Commands;
using BionicERP.Application.Inventory.StockBatchs.Models;
using BionicERP.Domain.Procurment;
using MediatR;
namespace BionicERP.Application.Procurment.PurchaseOrders.Commands {
    public class UpdatePurchaseOrderCommandHandler : IRequestHandler<UpdatePurchaseOrderCommand, Unit> {

        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public UpdatePurchaseOrderCommandHandler (IBionicERPDatabaseService database) {
            _database = database;

            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdatePurchaseOrderCommand, PurchaseOrder> ();

            }).CreateMapper ();

        }
        public async Task<Unit> Handle (UpdatePurchaseOrderCommand request, CancellationToken cancellationToken) {
            PurchaseOrder updatedOrder = await _database.PurchaseOrder.FindAsync (request.Id);

            if (updatedOrder == null) {
                throw new NotFoundException ("Purchase order", request.Id);
            }

            _Mapper.Map (request, updatedOrder);

            _database.PurchaseOrder.Update (updatedOrder);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}