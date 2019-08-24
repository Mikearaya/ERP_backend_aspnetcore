/*
 * @CreateTime: Aug 24, 2019 4:55 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 4:56 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.StockBatchs.Commands {
    public class UpdateStockBatchCommandValidator : AbstractValidator<UpdateStockBatchCommand> {
        public UpdateStockBatchCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
            RuleFor (x => x.Status).NotEmpty ().NotNull ();
            RuleFor (x => x.AvailableFrom).NotNull ();
        }
    }
}