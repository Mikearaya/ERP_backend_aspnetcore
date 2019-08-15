using BionicERP.Domain.CRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicERP.Persistence.CRM {
    public class InvoicePaymentsConfiguration
        : IEntityTypeConfiguration<InvoicePayments> {

            public void Configure (EntityTypeBuilder<InvoicePayments> builder) {
                builder.ToTable ("INVOICE_PAYMENTS");

                builder.HasIndex (e => e.InvoiceNo)
                    .HasName ("fk_INVOICE_PAYMENTS_INVOICE_idx");

                builder.HasIndex (e => e.PurchaseOrderId)
                    .HasName ("purchase_order_fk");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.Amount).HasColumnName ("amount");

                builder.Property (e => e.CheckNo)
                    .HasColumnName ("check_no")
                    .HasColumnType ("int(11)");

                builder.Property (e => e.Date)
                    .HasColumnName ("date")
                    .HasColumnType ("datetime");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.InvoiceNo).HasColumnName ("INVOICE_NO");

                builder.Property (e => e.Note)
                    .HasColumnName ("note")
                    .HasColumnType ("varchar(50)");

                builder.Property (e => e.PrintCount)
                    .HasColumnName ("print_count")
                    .HasColumnType ("int(11)")
                    .HasDefaultValueSql ("'0'");

                builder.Property (e => e.PurchaseOrderId).HasColumnName ("PURCHASE_ORDER_ID");

                builder.HasOne (d => d.InvoiceNoNavigation)
                    .WithMany (p => p.InvoicePayments)
                    .HasForeignKey (d => d.InvoiceNo)
                    .OnDelete (DeleteBehavior.Cascade)
                    .HasConstraintName ("fk_INVOICE_PAYMENTS_INVOICE");

                builder.HasOne (d => d.PurchaseOrder)
                    .WithMany (p => p.InvoicePayments)
                    .HasForeignKey (d => d.PurchaseOrderId)
                    .HasConstraintName ("purchase_order_fk");

            }
        }
}