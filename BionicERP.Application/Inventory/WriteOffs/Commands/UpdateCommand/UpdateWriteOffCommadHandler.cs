/*
 * @CreateTime: Sep 7, 2019 1:13 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 1:19 PM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Domain.Inventory;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.WriteOffs.Commands {
    public class UpdateWriteOffCommadHandler : IRequestHandler<UpdateWriteOffCommand, Unit> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public UpdateWriteOffCommadHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<UpdateWriteOffCommand, WriteOff> ();
            }).CreateMapper ();
        }

        public async Task<Unit> Handle (UpdateWriteOffCommand request, CancellationToken cancellationToken) {
            WriteOff writeOff = await _database.WriteOff
                .Include (w => w.WriteOffDetail)
                .FirstOrDefaultAsync (w => w.Id == request.Id);

            if (writeOff == null) {
                throw new NotFoundException (nameof (WriteOff), request.Id);
            }

            _Mapper.Map (request, writeOff);

            foreach (var data in request.WriteOffDetail) {
                var batch = await _database.StockBatchStorage
                    .Include (b => b.WriteOffDetail)
                    .AsNoTracking ()
                    .Where (b => b.Id == data.BatchStorageId)
                    .FirstOrDefaultAsync ();

                if (batch == null) {
                    throw new NotFoundException (nameof (StockBatchStorage), data.BatchStorageId);

                    // check if there is available stock 
                } else if (batch.Quantity < data.Quantity) {
                    throw new QuantityGreaterThanAvailableException (
                        nameof (WriteOff),
                        data.Quantity,
                        batch.Quantity);
                }

                writeOff.WriteOffDetail.Add (new WriteOffDetail () {
                    WriteOffId = request.Id,
                        BatchStorageId = data.BatchStorageId,
                        Quantity = data.Quantity,
                });
            }

            _database.WriteOff.Update (writeOff);
            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}