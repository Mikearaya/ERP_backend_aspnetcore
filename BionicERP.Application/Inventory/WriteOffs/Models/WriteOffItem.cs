/*
 * @CreateTime: Sep 7, 2019 12:53 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 7, 2019 12:59 PM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Inventory.WriteOffs.Models {
    public class WriteOffItem {
        public uint BatchStorageId { get; set; }
        public uint? WriteOffId { get; set; }
        public float Quantity { get; set; }

    }
}