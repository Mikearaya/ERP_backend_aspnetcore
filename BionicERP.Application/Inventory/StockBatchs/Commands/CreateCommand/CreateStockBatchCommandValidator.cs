/*
 * @CreateTime: Aug 9, 2019 11:29 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 9, 2019 1:47 PM
 * @Description: Modify Here, Please  
 */
using BionicERP.Application.Inventory.StockBatchs.Models;
using FluentValidation;

namespace BionicERP.Application.Inventory.StockBatchs.Commands {
    public class CreateStockBatchCommandValidator : AbstractValidator<CreateStockBatchCommand> {
        public CreateStockBatchCommandValidator () {
            RuleFor (x => x.ItemId).NotNull ();
            RuleFor (x => x.Quantity).NotNull ().NotEqual (0);
            RuleFor (x => x.Status).NotNull ().NotEmpty ();
            RuleFor (x => x.StorageLocation.Count).NotEqual (0);
            RuleFor (x => x.AvailableFrom).NotNull ();
            RuleForEach (x => x.StorageLocation).SetValidator (new StorageLocationValidator ());
        }

        public class StorageLocationValidator : AbstractValidator<NewStockBatchStorageDto> {
            public StorageLocationValidator () {
                RuleFor (x => x.Quantity).NotNull ().NotEqual (0);
                RuleFor (x => x.StorageId).NotNull ();
            }
        }
    }
}