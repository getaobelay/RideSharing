using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Common;
using RideSharing.Domain.Drivers;
using RideSharing.Domain.Locations;

namespace RideSharing.Infrastructure.Context.Configurations
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(d => d.Id);


            builder.HasMany(t => t.StartLocations)
                             .WithOne(l => l.StartLocation)
                             .HasForeignKey(t => t.StartLocationId)
                             .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(t => t.EndLocations)
                           .WithOne(l => l.EndLocation)
                           .HasForeignKey(t => t.EndLocationId)
                           .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
