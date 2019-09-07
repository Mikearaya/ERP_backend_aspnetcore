/*
 * @CreateTime: Sep 7, 2019 1:01 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 2:18 PM
 * @Description: Modify Here, Please  
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BionicERP.Application.Exceptions;
using BionicERP.Application.Interfaces;
using BionicERP.Application.Inventory.WriteOffs.Models;
using BionicERP.Domain.Inventory;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Inventory.WriteOffs.Commands {
    public class CreateWriteOffCommandHandler : IRequestHandler<CreateWriteOffCommand, uint> {
        private readonly IBionicERPDatabaseService _database;
        private IMapper _Mapper;
        public CreateWriteOffCommandHandler (IBionicERPDatabaseService database) {
            _database = database;
            _Mapper = new MapperConfiguration (x => {
                x.CreateMap<CreateWriteOffCommand, WriteOff> ();
                x.CreateMap<WriteOffItem, WriteOffDetail> ();
            }).CreateMapper ();
        }

        public async Task<uint> Handle (CreateWriteOffCommand request, CancellationToken cancellationToken) {
            WriteOff writeOff = _Mapper.Map<CreateWriteOffCommand, WriteOff> (request);

            writeOff.WriteOffDetail = new List<WriteOffDetail> ();

            foreach (var data in request.WriteOffDetail) {
                var batch = await _database.StockBatchStorage
                    .Include (s => s.Batch)
                    .Where (b => b.Id == data.BatchStorageId)
                    .FirstOrDefaultAsync ();

                if (batch == null) {
                    throw new NotFoundException (nameof (StockBatchStorage), data.BatchStorageId);
                } else if (batch.Quantity < data.Quantity) {
                    throw new QuantityGreaterThanAvailableException (
                        nameof (WriteOff),
                        data.Quantity,
                        batch.Quantity);
                }

                batch.Quantity = batch.Quantity - data.Quantity;
                batch.Batch.Quantity = batch.Batch.Quantity - data.Quantity;

                writeOff.WriteOffDetail.Add (new WriteOffDetail () {
                    BatchStorageId = data.BatchStorageId,
                        Quantity = data.Quantity,
                });
                // update storage
                _database.StockBatchStorage.Update (batch);

            }
            await _database.WriteOff.AddAsync (writeOff);
            await _database.SaveAsync ();

            return writeOff.Id;
        }
    }
}