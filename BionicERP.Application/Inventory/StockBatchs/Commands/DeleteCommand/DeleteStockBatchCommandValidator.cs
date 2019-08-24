/*
 * @CreateTime: Aug 24, 2019 5:01 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 24, 2019 5:02 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Inventory.StockBatchs.Commands {
    public class DeleteStockBatchCommandValidator : AbstractValidator<DeleteStockBatchCommand> {
        public DeleteStockBatchCommandValidator () {
            RuleFor (x => x.Id).NotNull ();
        }
    }
}