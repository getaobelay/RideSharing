using RideSharing.Abstractions.Domain;
using RideSharing.Abstractions.Extensions;
using RideSharing.Domain.Common;
using RideSharing.Domain.Customers.Validations;
using RideSharing.Domain.Locations;
using RideSharing.Domain.Trips;
using RideSharing.Domain.Trips.Events;
using RideSharing.Domain.Trips.ValueObjects;

namespace RideSharing.Domain.Customers
{
    public class Customer : AggregateRoot
    {
        private Customer() { }

        internal Customer(Person person)
        {


            Person = person;
            CreatedAt = DateTime.UtcNow;

            this.Validate<Customer, CustomerValidator>();
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

            var tripLocation = new TripLocation(startLocation, endLocation);

            var trip = new Trip(this, tripLocation);

            _trips.Add(trip);

            AddDomainEvent(new TripCreatedEvent(this, trip));
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
