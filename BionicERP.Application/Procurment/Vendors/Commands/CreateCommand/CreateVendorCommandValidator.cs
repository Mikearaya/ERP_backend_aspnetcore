/*
 * @CreateTime: Aug 5, 2019 1:58 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:01 PM
 * @Description: Modify Here, Please  
 */
using FluentValidation;

namespace BionicERP.Application.Procurment.Vendors.Commands {
    public class CreateVendorCommandValidator : AbstractValidator<CreateVendorCommand> {
        public CreateVendorCommandValidator () {
            RuleFor (x => x.Name).NotNull ().NotEmpty ();
            RuleFor (x => x.PhoneNumber).NotNull ().NotEmpty ();
        }
    }
}