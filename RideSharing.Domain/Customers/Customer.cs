using RideSharing.Abstractions.Domain;
using RideSharing.Abstractions.Extensions;
using RideSharing.Domain.Common;
using RideSharing.Domain.Customers.Validations;
using RideSharing.Domain.Trips;
using RideSharing.Shared.Enums;

namespace RideSharing.Domain.Customers
{
    public class Customer : AggregateRoot
    {
        private Customer() { }

        internal Customer(Person person)
        {


            PersonInfo = person;
            CreatedAt = DateTime.UtcNow;

            this.Validate<Customer, CustomerValidator>();
        }

        public Person PersonInfo { get; private set; }
        public DateTime CreatedAt { get; }
        private readonly List<Trip> _trips = new();
        public IReadOnlyCollection<Trip> Trips => _trips.AsReadOnly();


        public static Customer Create(string firstName, string lastName, string middleName, string phone, string email, Gender gender, DateTime dateOfBirth)
        {
            var person = new Person(firstName, lastName, middleName, phone, email, gender, dateOfBirth);
            var customer = new Customer(person);

            return customer.Validate<Customer, CustomerValidator>();
        }


        public void AddTrip(Trip trip)
        {
            if (trip is null)
            {
                throw new ArgumentNullException(nameof(trip));
            }

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
