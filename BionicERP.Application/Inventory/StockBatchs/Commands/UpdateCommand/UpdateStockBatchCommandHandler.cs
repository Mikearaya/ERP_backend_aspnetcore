/*
 * @CreateTime: Aug 24, 2019 4:56 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 5:01 PM
 * @Description: Modify Here, Please  
 */
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;

namespace BionicERP.Application.Inventory.StockBatchs.Commands {
    public class UpdateStockBatchCommandHandler : IRequestHandler<UpdateStockBatchCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public UpdateStockBatchCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateStockBatchCommand, StockBatch> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateStockBatchCommand request, CancellationToken cancellationToken) {
            StockBatch batch = await _database.StockBatch.FindAsync (request.Id);

            if (batch == null) {
                throw new NotFoundException (nameof (StockBatch), request.Id);
            }

            batch.AvailableFrom = request.AvailableFrom;
            batch.ExpiryDate = request.ExpiryDate;

            if (request.Status.Trim ().ToUpper () == "RECIEVED" && batch.Status.Trim ().ToUpper () != "RECIEVED") {
                batch.Status = "Recieved";
            } else if (request.Status.Trim ().ToUpper () == "PLANED" && batch.Status.Trim ().ToUpper () == "RECIEVED") {
                batch.Status = "Planed";
            }

            _database.StockBatch.Update (batch);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}