using RideSharing.Abstractions.Extensions;
using RideSharing.Domain.Locations;
using RideSharing.Domain.Trips.Validations;

namespace RideSharing.Domain.Trips.ValueObjects
{
    public class TripLocation
    {
        protected TripLocation() { }

        internal TripLocation(Location startLocation, Location endLocation)
        {
            StartLocation = startLocation;
            EndLocation = endLocation;

            this.Validate<TripLocation, TripLocationValidator>();
        }

        public Guid StartLocationId { get; }
        public Location StartLocation { get; private set; }
        public Guid EndLocationId { get; }
        public Location EndLocation { get; private set; }


        public void UpdateStartLocation(Location startLocation)
        {
            if (startLocation is null)
            {
                throw new ArgumentNullException(nameof(startLocation));
            }

            StartLocation = startLocation;
        }

        public void UpdateEndLocation(Location endLocation)
        {
            if (endLocation is null)
            {
                throw new ArgumentNullException(nameof(endLocation));

            }

            EndLocation = endLocation;
        }

    }
}
