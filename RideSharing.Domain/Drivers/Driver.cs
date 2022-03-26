using RideSharing.Abstractions.Domain;
using RideSharing.Abstractions.Extensions;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Common;
using RideSharing.Domain.Drivers.Validations;
using RideSharing.Domain.Trips;
using RideSharing.Domain.Trips.Enums;
using RideSharing.Domain.Trips.Events;

namespace RideSharing.Domain.Drivers
{
    public sealed class Driver : AggregateRoot
    {

        private Driver() { }

        internal Driver(Person person, Car car, string licenseNo)
        {

            Person = person;
            CurrentCar = car;
            LicenseNo = licenseNo;
            CreatedAt = DateTime.UtcNow;

            this.Validate<Driver, DriverValidator>();
        }


        public Person Person { get; private set; }
        public string LicenseNo { get; private set; }
        public DateTime CreatedAt { get; }
        public Guid CurrentCarId { get; private set; }
        public Car CurrentCar { get; private set; }
        public Guid CarId { get; private set; }
        private readonly List<Car> _cars = new();
        public IReadOnlyCollection<Car> Cars => _cars.AsReadOnly();

        private readonly List<Trip> _trips = new();
        public IReadOnlyCollection<Trip> Trips => _trips.AsReadOnly();

        public void UpdatePerson(Person person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            Person = person;
        }

        public void UpdateLicenseNo(string licenseNo)
        {
            if (string.IsNullOrWhiteSpace(licenseNo))
            {
                throw new ArgumentException($"'{nameof(licenseNo)}' cannot be null or whitespace.", nameof(licenseNo));
            }


            LicenseNo = licenseNo;
        }

        public void UpdateCar(Car car)
        {
            if (car is null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            CurrentCar = car;
        }

        public void AddTrip(Trip trip)
        {
            if (trip is null)
            {
                throw new ArgumentNullException(nameof(trip));
            }

            trip.AssignToDriver(this);

            _trips.Add(trip);

            AddDomainEvent(new TripAddedEvent(this, trip));
        }


        public void CompleteTrip(Guid tripId)
        {
            var trip = _trips.SingleOrDefault();

            if (!_trips.Any(t => t.Id == tripId))
            {
                throw new InvalidOperationException(nameof(trip));
            }

            _trips.SingleOrDefault(t => t.Id == tripId)?.Complete();

        }

        public void UpdateTripRating(Guid tripId, int rating)
        {
            var trip = _trips.SingleOrDefault(t => t.Id == tripId);

            if (trip is null)
            {
                throw new InvalidOperationException(nameof(trip));
            }

            trip.UpdateDriverRating(rating);
        }

    }
}