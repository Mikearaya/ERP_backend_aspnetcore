/*
 * @CreateTime: Aug 4, 2019 8:48 PM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 5, 2019 2:40 PM
 * @Description: Modify Here, Please  
 */
using System;
using System.Threading.Tasks;
using BionicERP.Application.Interfaces;
using BionicERP.Domain;
using BionicERP.Domain.CRM;
using BionicERP.Domain.Identity;
using BionicERP.Domain.Inventory;
using BionicERP.Domain.Procurment;
using BionicERP.Domain.Production;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BionicERP.Persistence {
    public class BionicERPDatabaseService : IdentityDbContext<ApplicationUser, ApplicationRole, string, UserClaims, UserRoles, UserLogins, RoleClaims, UserTokens>, IBionicERPDatabaseService {

        public BionicERPDatabaseService () { }
        public BionicERPDatabaseService (DbContextOptions<BionicERPDatabaseService> options) : base (options) { }
        public void Save () {
            this.SaveChanges ();
        }

        public Task SaveAsync () {
            return this.SaveChangesAsync ();
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<FinishedProduct> FinishedProduct { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<InvoicePayments> InvoicePayments { get; set; }
        public DbSet<ShipmentDetail> ShipmentDetail { get; set; }
        public DbSet<Shipment> Shipment { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<ProductionOrderList> ProductionOrderList { get; set; }
        public DbSet<CustomerOrder> CustomerOrder { get; set; }
        public DbSet<CustomerOrderItem> CustomerOrderItem { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<BookedStockItems> BookedStockItems { get; set; }
        public DbSet<Bom> Bom { get; set; }
        public DbSet<BomItems> BomItems { get; set; }
        public DbSet<ProductGroup> ProductGroup { get; set; }
        public DbSet<UnitOfMeasurment> UnitsOfMeasurment { get; set; }
        public DbSet<Workstation> WorkStation { get; set; }
        public DbSet<WorkstationGroup> WorkStationGroup { get; set; }
        public DbSet<Routing> Routing { get; set; }
        public DbSet<RoutingOperation> RoutingDetail { get; set; }
        public DbSet<StorageLocation> StorageLocation { get; set; }
        public DbSet<RoutingBoms> RoutingBoms { get; set; }
        public DbSet<WriteOff> WriteOff { get; set; }
        public DbSet<WriteOffDetail> WriteOffDetail { get; set; }

        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<VendorPurchaseTerm> VendorPurchaseTerm { get; set; }
        public DbSet<StockBatch> StockBatch { get; set; }
        public DbSet<StockBatchStorage> StockBatchStorage { get; set; }
        public DbSet<BookedStockBatch> BookedStockBatch { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderQuotation> PurchaseOrderQuotation { get; set; }
        public DbSet<SystemSettings> SystemSettings { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder) {
            if (!optionBuilder.IsConfigured) {
                optionBuilder.UseMySql ("server=localhost;user=admin;password=admin;port=3306;database=bionic_erp;");
            }

        }

        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating (builder);
            builder.ApplyConfigurationsFromAssembly (typeof (BionicERPDatabaseService).Assembly);

        }
    }
}