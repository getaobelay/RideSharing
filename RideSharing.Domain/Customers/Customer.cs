using RideSharing.Domain.Common;
using RideSharing.Domain.Locations;
using RideSharing.Domain.Trips;

namespace RideSharing.Domain.Customers
{
    public class Customer
    {
        private Customer() { }

        internal Customer(Person person)
        {


            Person = person ?? throw new ArgumentNullException(nameof(person));
            CreatedAt = DateTime.UtcNow;
        }

        public Person Person { get; private set; }
        public DateTime CreatedAt { get; }
        private readonly List<Trip> _trips = new();
        public IReadOnlyCollection<Trip> Trips => _trips.AsReadOnly();


        public void AddTrip(Location startLocation, Location endLocation)
        {
            if (startLocation is null)
            {
                throw new ArgumentNullException(nameof(startLocation));
            }

            if (endLocation is null)
            {
                throw new ArgumentNullException(nameof(endLocation));
            }

            var trip = new Trip(this, startLocation, endLocation);

            _trips.Add(trip);
        }

        public void UpdateTripRating(Guid tripId, int rating)
        {
            var trip = _trips.SingleOrDefault(t => t.Id == tripId);

            if (trip is null)
            {
                throw new InvalidOperationException(nameof(trip));
            }

            trip.UpdateCustomerRating(rating);
        }

    }
}
