using RideSharing.Domain.Trips;
namespace RideSharing.Domain.Trips.ValueObjects
{
    public class TripRating
    {
        private TripRating() { }
        internal TripRating(int customerRating = 0, int driverRating = 0)
        {
            CustomerRating = customerRating;
            DriverRating = driverRating;
        }

        public int CustomerRating { get; private set; }
        public int DriverRating { get; private set; }

        public void UpdateCustomerRating(int rating = 0)
        {
            CustomerRating = rating;
        }

        public void UpdateDriverRating(int rating = 0)
        {
            DriverRating = rating;
        }
    }
}
