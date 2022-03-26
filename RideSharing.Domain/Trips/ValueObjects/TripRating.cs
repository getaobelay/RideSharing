using RideSharing.Domain.Trips;
namespace RideSharing.Domain.Trips.ValueObjects
{
    public class TripRating
    {

        public int CustomerRating { get; private set; }
        public int DriverRating { get; private set; }
    }
}
