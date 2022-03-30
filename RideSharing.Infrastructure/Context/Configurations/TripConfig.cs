using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Common;
using RideSharing.Domain.Drivers;
using RideSharing.Domain.Locations;
using RideSharing.Domain.Trips;
using RideSharing.Domain.Trips.ValueObjects;

namespace RideSharing.Infrastructure.Context.Configurations
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Customer).WithMany(c => c.Trips).HasForeignKey(t => t.CustomerId);



            builder.OwnsOne(d => d.TripDate, tripdBuilder =>
            {
                tripdBuilder.Property(d => d.StartTimestamp).HasColumnName(nameof(TripDate.StartTimestamp));
                tripdBuilder.Property(d => d.EndTimestamp).HasColumnName(nameof(TripDate.EndTimestamp));
                tripdBuilder.Property(d => d.WaitTime).HasColumnName(nameof(TripDate.WaitTime));
                tripdBuilder.Property(d => d.RequestdTimestamp).HasColumnName(nameof(TripDate.RequestdTimestamp)).IsRequired();

            });


            builder.OwnsOne(d => d.TripRating, tripdBuilder =>
            {
                tripdBuilder.Property(d => d.CustomerRating).HasColumnName(nameof(TripRating.CustomerRating));
                tripdBuilder.Property(d => d.DriverRating).HasColumnName(nameof(TripRating.DriverRating));
            });




        }
    }
}
