using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Common;
using RideSharing.Domain.Drivers;

namespace RideSharing.Infrastructure.Context.Configurations
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Manufacture).HasMaxLength(50).IsRequired();
            builder.Property(d => d.Model).HasMaxLength(50).IsRequired();


            builder.HasMany(c => c.DriverCars).WithOne(d => d.Car).HasForeignKey(c => c.DriverId);

        }
    }
}
