/*
 * @CreateTime: Nov 29, 2018 11:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 6, 2018 12:20 AM
 * @Description: Modify Here, Please 
 */

using BionicERP.Domain.Production;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicERP.Persistence.Production {
    public class BillOfMaterialsConfigurations : IEntityTypeConfiguration<Bom> {
        public void Configure (EntityTypeBuilder<Bom> builder) {

            builder.ToTable ("BOM");

            builder.HasIndex (e => e.ItemId)
                .HasName ("fk_BOM_item_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Active)
                .HasColumnName ("active")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'1'");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("CURRENT_TIMESTAMP");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.ItemId).HasColumnName ("ITEM_ID");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

            builder.HasOne (d => d.Item)
                .WithMany (p => p.Bom)
                .HasForeignKey (d => d.ItemId)
                .HasConstraintName ("fk_BOM_item");
        }
    }
}