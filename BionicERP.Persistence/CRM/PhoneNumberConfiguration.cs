/*
 * @CreateTime: Nov 27, 2018 3:06 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 3:28 PM
 * @Description: Modify Here, Please 
 */

using BionicERP.Domain.CRM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicERP.Persistence.CRM {
    public class PhoneNumberConfiguration
        : IEntityTypeConfiguration<PhoneNumber> {

            public void Configure (EntityTypeBuilder<PhoneNumber> builder) {
                builder.ToTable ("PHONE_NUMBER");

                builder.HasIndex (e => e.ClientId)
                    .HasName ("fk_PHONE_NUMBER_client_idx");

                builder.HasIndex (e => e.Number)
                    .HasName ("number_UNIQUE")
                    .IsUnique ();

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.ClientId).HasColumnName ("CLIENT_ID");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("CURRENT_TIMESTAMP");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.Number)
                    .IsRequired ()
                    .HasColumnName ("number")
                    .HasColumnType ("varchar(13)");

                builder.Property (e => e.Type)
                    .IsRequired ()
                    .HasColumnName ("type")
                    .HasColumnType ("varchar(30)");

                builder.HasOne (d => d.Client)
                    .WithMany (p => p.PhoneNumber)
                    .HasForeignKey (d => d.ClientId)
                    .HasConstraintName ("fk_PHONE_NUMBER_client");
            }
        }
}