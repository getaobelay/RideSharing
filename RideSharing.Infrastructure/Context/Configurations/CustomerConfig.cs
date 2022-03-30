using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Common;
using RideSharing.Domain.Customers;
using RideSharing.Domain.Drivers;

namespace RideSharing.Infrastructure.Context.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(d => d.Id);

            builder.OwnsOne(d => d.PersonInfo, driverBuilder =>
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
