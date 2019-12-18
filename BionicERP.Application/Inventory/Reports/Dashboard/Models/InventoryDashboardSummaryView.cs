/*
 * @CreateTime: Dec 18, 2019 8:38 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 18, 2019 8:52 AM
 * @Description: Modify Here, Please  
 */
namespace BionicERP.Application.Inventory.Reports.Dashboard.Models {
    public class InventoryDashboardSummaryView {
        public int TotalItems { get; set; }
        public decimal TotalPlannedItems { get; set; }
        public decimal TotalBookedShippings { get; set; }
        public decimal? TotalPickedShippings { get; set; }
        public decimal TotalWriteOffItems { get; set; }
        public decimal TotalRecievedItems { get; set; }
    }
}