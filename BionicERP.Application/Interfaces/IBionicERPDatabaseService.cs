/*
 * @CreateTime: Jul 22, 2019 1:06 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 12:05 PM
 * @Description: Modify Here, Please  
 */
using System.Threading.Tasks;
using BionicERP.Domain;
using BionicERP.Domain.CRM;
using BionicERP.Domain.Identity;
using BionicERP.Domain.Inventory;
using BionicERP.Domain.Procurment;
using BionicERP.Domain.Production;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Application.Interfaces {
    public interface IBionicERPDatabaseService {

        DbSet<Address> Address { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Company> Company { get; set; }
        DbSet<Employee> Employee { get; set; }
        DbSet<FinishedProduct> FinishedProduct { get; set; }
        DbSet<Invoice> Invoice { get; set; }
        DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        DbSet<InvoicePayments> InvoicePayments { get; set; }
        DbSet<ShipmentDetail> ShipmentDetail { get; set; }
        DbSet<Shipment> Shipment { get; set; }
        DbSet<Item> Item { get; set; }
        DbSet<PhoneNumber> PhoneNumber { get; set; }
        DbSet<ProductionOrderList> ProductionOrderList { get; set; }
        DbSet<CustomerOrder> CustomerOrder { get; set; }
        DbSet<CustomerOrderItem> CustomerOrderItem { get; set; }
        DbSet<SocialMedia> SocialMedia { get; set; }
        DbSet<BookedStockItems> BookedStockItems { get; set; }
        DbSet<Bom> Bom { get; set; }
        DbSet<BomItems> BomItems { get; set; }
        DbSet<ProductGroup> ProductGroup { get; set; }
        DbSet<UnitOfMeasurment> UnitsOfMeasurment { get; set; }
        DbSet<Workstation> WorkStation { get; set; }
        DbSet<WorkstationGroup> WorkStationGroup { get; set; }
        DbSet<Routing> Routing { get; set; }
        DbSet<RoutingOperation> RoutingDetail { get; set; }
        DbSet<StorageLocation> StorageLocation { get; set; }
        DbSet<RoutingBoms> RoutingBoms { get; set; }
        DbSet<WriteOff> WriteOff { get; set; }
        DbSet<WriteOffDetail> WriteOffDetail { get; set; }

        DbSet<Vendor> Vendor { get; set; }
        DbSet<VendorPurchaseTerm> VendorPurchaseTerm { get; set; }
        DbSet<StockBatch> StockBatch { get; set; }
        DbSet<StockBatchStorage> StockBatchStorage { get; set; }
        DbSet<BookedStockBatch> BookedStockBatch { get; set; }

        DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        DbSet<PurchaseOrderQuotation> PurchaseOrderQuotation { get; set; }
        DbSet<SystemSettings> SystemSettings { get; set; }

        DbSet<RoleClaims> RoleClaims { get; set; }
        DbSet<ApplicationRole> Roles { get; set; }
        DbSet<UserClaims> UserClaims { get; set; }
        DbSet<UserLogins> UserLogins { get; set; }
        DbSet<UserRoles> UserRoles { get; set; }
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<UserTokens> UserTokens { get; set; }
        DbSet<SystemLookup> SystemLookups { get; set; }

        void Save ();
        Task SaveAsync ();

    }
}