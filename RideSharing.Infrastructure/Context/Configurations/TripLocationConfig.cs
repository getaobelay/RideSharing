using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Common;
using RideSharing.Domain.Drivers;
using RideSharing.Domain.Trips;

namespace RideSharing.Infrastructure.Context.Configurations
{
    public class TripLocationConfig : IEntityTypeConfiguration<TripLocation>
    {
        public void Configure(EntityTypeBuilder<TripLocation> builder)
        {
            builder.HasKey(d => d.Id);



        }
    }
}
