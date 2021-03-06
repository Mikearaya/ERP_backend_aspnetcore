/*
 * @CreateTime: Oct 26, 2018 10:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 14, 2018 11:33 PM
 * @Description: Modify Here, Please 
 */

using BionicERP.Domain.CRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicERP.Persistence.CRM {
    public class InvoiceDetailConfiguration
        : IEntityTypeConfiguration<InvoiceDetail> {

            public void Configure (EntityTypeBuilder<InvoiceDetail> builder) {

                builder.ToTable ("INVOICE_DETAIL");

                builder.HasIndex (e => e.InvoiceNo)
                    .HasName ("fk_INVOICE_ID_idx");

                builder.HasIndex (e => e.SalesOrderId)
                    .HasName ("fk_SALE_DETAIL_INVENTORY_ID_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.DateAddded)
                    .HasColumnName ("date_addded")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("CURRENT_TIMESTAMP");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.InvoiceNo).HasColumnName ("INVOICE_NO");

                builder.Property (e => e.Note)
                    .HasColumnName ("note")
                    .HasColumnType ("varchar(255)");

                builder.Property (e => e.Quantity)
                    .HasColumnName ("quantity")
                    .HasColumnType ("int(11)");

                builder.Property (e => e.SalesOrderId).HasColumnName ("SALES_ORDER_ID");

                builder.Property (e => e.Tax)
                    .HasColumnName ("tax")
                    .HasDefaultValueSql ("'0'");

                builder.Property (e => e.UnitPrice).HasColumnName ("unit_price");

                builder.HasOne (d => d.InvoiceNoNavigation)
                    .WithMany (p => p.InvoiceDetail)
                    .HasForeignKey (d => d.InvoiceNo)
                    .HasConstraintName ("fk_INVOICE_ID");

                builder.HasOne (d => d.CustomerOrderItem)
                    .WithMany (p => p.InvoiceDetail)
                    .HasForeignKey (d => d.SalesOrderId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_INVOICE_DETAIL_order_item");
            }
        }
}