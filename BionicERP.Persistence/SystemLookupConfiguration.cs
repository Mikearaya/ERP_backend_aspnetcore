/*
 * @CreateTime: Sep 10, 2019 11:51 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 10, 2019 11:52 AM
 * @Description: Modify Here, Please  
 */
using BionicERP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicERP.Persistence {
    public class SystemLookupConfiguration : IEntityTypeConfiguration<SystemLookup> {
        public void Configure (EntityTypeBuilder<SystemLookup> builder) {
            builder.ToTable ("SYSTEM_LOOKUP");

            builder.Property (e => e.Id)
                .HasColumnName ("ID")
                .HasColumnType ("int(10)");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.IsSystem)
                .HasColumnName ("is_system")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Type)
                .IsRequired ()
                .HasColumnName ("type")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.Value)
                .IsRequired ()
                .HasColumnName ("value")
                .HasColumnType ("varchar(100)");

        }
    }
}