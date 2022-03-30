using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideSharing.Domain.Common;
using RideSharing.Domain.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharing.Infrastructure.Context.Configurations
{
    public class DriverConfig : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.LicenseNo).HasMaxLength(20).IsRequired();

            builder.OwnsOne(d => d.Person, driverBuilder =>
            {
                driverBuilder.Property(d => d.FirstName).HasColumnName(nameof(Person.FirstName)).HasMaxLength(20).IsRequired();
                driverBuilder.Property(d => d.LastName).HasColumnName(nameof(Person.LastName)).HasMaxLength(20).IsRequired();
                driverBuilder.Property(d => d.MiddleName).HasColumnName(nameof(Person.MiddleName)).HasMaxLength(20);
                driverBuilder.Property(d => d.Phone).HasColumnName(nameof(Person.Phone)).IsRequired();
                driverBuilder.Property(d => d.DateOfBirth).HasColumnName(nameof(Person.DateOfBirth)).IsRequired();

            });
        }
    }
}
