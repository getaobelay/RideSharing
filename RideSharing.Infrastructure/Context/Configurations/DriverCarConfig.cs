using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideSharing.Domain.Drivers;

namespace RideSharing.Infrastructure.Context.Configurations
{
    public class DriverCarConfig : IEntityTypeConfiguration<DriverCar>
    {
        public void Configure(EntityTypeBuilder<DriverCar> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.LicensePlateNo).HasMaxLength(20).IsRequired();

            builder.Property(d => d.IsCurrent).IsRequired();

            builder.HasOne(c => c.Car).WithMany(d => d.DriverCars).HasForeignKey(c => c.CarId);
            builder.HasOne(c => c.Driver).WithMany(d => d.DriverCars).HasForeignKey(c => c.DriverId);
            builder.HasMany(c => c.Trips).WithOne(d => d.DriverCar).HasForeignKey(c => c.DriverCarId);

        }
    }
}
