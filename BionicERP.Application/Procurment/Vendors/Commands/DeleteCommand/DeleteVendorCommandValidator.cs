/*
 * @CreateTime: Aug 5, 2019 2:04 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:06 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Procurment.Vendors.Commands {
    public class DeleteVendorCommandValidator : AbstractValidator<DeleteVendorCommand> {
        public DeleteVendorCommandValidator () {
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
        }
    }
}