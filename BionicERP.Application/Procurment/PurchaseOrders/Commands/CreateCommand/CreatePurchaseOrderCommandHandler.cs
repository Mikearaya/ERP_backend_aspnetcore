/*
 * @CreateTime: Aug 9, 2019 1:51 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 2:00 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.StockBatchs.Commands;
using BionicERP.Application.Inventory.StockBatchs.Models;
using BionicERP.Domain.Procurment;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Procurment.PurchaseOrders.Commands {
    public class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        private readonly IMediator _Mediator;

        public CreatePurchaseOrderCommandHandler (IBionicERPDatabaseService database, IMediator mediator) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreatePurchaseOrderCommand, PurchaseOrder> ();

            }).CreateMapper ();
            _Mediator = mediator;
        }

        public async Task<uint> Handle (CreatePurchaseOrderCommand request, CancellationToken cancellationToken) {
            bool Recieved = false;
            PurchaseOrder purchaseOrder = _Mapper.Map<CreatePurchaseOrderCommand, PurchaseOrder> (request);

            if (request.OrderedDate != null) {
                purchaseOrder.Status = "Ordered";
            }

            if (request.ShippedDate != null) {
                purchaseOrder.Status = "Shipped";
            }

            if (request.ArivalDate != null) {
                purchaseOrder.Status = "Recieved";
                Recieved = true;
            }

            _database.PurchaseOrder.Add (purchaseOrder);
            await _database.SaveAsync ();

            foreach (var item in request.PurchaseOrderItems) {
                // check if the selected vendor item exists
                var vendorItem = await _database.VendorPurchaseTerm
                    .Include (v => v.Item)
                    .AsNoTracking ()
                    .Where (v => v.VendorId == request.VendorId && v.ItemId == item.ItemId)
                    .OrderByDescending (v => v.Priority)
                    .FirstOrDefaultAsync ();

                if (vendorItem == null) {
                    throw new NotFoundException ("Vendor Item", item.ItemId);
                }

                await _Mediator.Send (new CreateStockBatchCommand () {

                    PurchaseOrderId = purchaseOrder.Id,
                        ItemId = vendorItem.ItemId,
                        Quantity = item.Quantity,
                        Status = Recieved ? "Recieved" : "Planed",
                        UnitCost = item.UnitPrice,
                        AvailableFrom = (item.ExpectedDate == null) ? request.ExpectedDate : (DateTime) item.ExpectedDate,
                        StorageLocation = new List<NewStockBatchStorageDto> () {
                            new NewStockBatchStorageDto () {
                                Quantity = item.Quantity,
                                    StorageId = vendorItem.Item.DefaultStorageId
                            }
                        }

                });

            }

            return purchaseOrder.Id;
        }

    }
}