/*
 * @CreateTime: Sep 26, 2018 1:15 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Aug 4, 2019 8:51 PM
 * @Description: Modify Here, Please 
 */

using BionicERP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicERP.Persistence {
    public class EmployeeConfiguration
        : IEntityTypeConfiguration<Employee> {

            public void Configure (EntityTypeBuilder<Employee> builder) {
                builder.ToTable ("EMPLOYEE");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.FirstName)
                    .IsRequired ()
                    .HasColumnName ("first_name")
                    .HasColumnType ("varchar(45)");

                builder.Property (e => e.LastName)
                    .IsRequired ()
                    .HasColumnName ("last_name")
                    .HasColumnType ("varchar(45)");
            }
        }
}