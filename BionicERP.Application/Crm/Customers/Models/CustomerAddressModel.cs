/*
 * @CreateTime: Sep 7, 2019 4:51 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 5:01 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Crm.Customers.Models {
    public class CustomerAddressModel {
        public uint? Id { get; set; } = 0;

        public string Location { get; set; }
        public string City { get; set; }

        public string SubCity { get; set; }

        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}