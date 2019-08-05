/*
 * @CreateTime: Aug 5, 2019 2:07 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:08 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Procurment.Vendors.Commands {
    public class UpdateVendorCommandValidator : AbstractValidator<UpdateVendorCommand> {
        public UpdateVendorCommandValidator () {
            RuleFor (x => x.Id).NotNull ().NotEmpty ();
            RuleFor (x => x.Name).NotNull ().NotEmpty ();
            RuleFor (x => x.PhoneNumber).NotNull ().NotEmpty ();
        }
    }
}