using RideSharing.Domain.Locations;
using RideSharing.Domain.Trips;
namespace RideSharing.Domain.Trips.ValueObjects
{
    public class TripLocation
    {
        private TripLocation() { }

        internal TripLocation(Location startLocation, Location endLocation)
        {
            StartLocation = startLocation ?? throw new ArgumentNullException(nameof(startLocation));
            EndLocation = endLocation ?? throw new ArgumentNullException(nameof(endLocation));
        }

        public Guid StartLocationId { get; }
        public Location StartLocation { get; private set; }
        public Guid EndLocationId { get; }
        public Location EndLocation { get; private set; }


        public void UpdateStartLocation(Location startLocation)
        {
            if (startLocation == null)
            {

            }

            StartLocation = startLocation;
        }

        public void UpdateEndLocation(Location endLocation)
        {
            if (endLocation == null)
            {

            }

            EndLocation = endLocation;
        }

    }
}
