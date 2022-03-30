using RideSharing.Abstractions.Domain;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Trips;

namespace RideSharing.Domain.Drivers
{
    public sealed class DriverCar : AggregateRoot
    {

        private DriverCar() { }

        internal DriverCar(Driver driver, Car car, string licensePlateNo)
        {
            Driver = driver;
            Car = car;
            LicensePlateNo = licensePlateNo;
            CreatedAt = DateTime.UtcNow;
        }

        public DateTime CreatedAt { get; }
        public string LicensePlateNo { get; private set; }
        public bool IsCurrent { get; private set; }
        public Guid DriverId { get; set; }
        public Driver Driver { get; private set; }

        public Guid CarId { get; private set; }
        public Car Car { get; private set; }

        public Guid TripId { get; private set; }


        private readonly List<Trip> _trips = new();
        public IReadOnlyCollection<Trip> Trips => _trips.AsReadOnly();


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