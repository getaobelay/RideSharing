using RideSharing.Abstractions.Domain;
using RideSharing.Abstractions.Extensions;
using RideSharing.Domain.Customers;
using RideSharing.Domain.Drivers;
using RideSharing.Domain.Locations;
using RideSharing.Domain.Trips.Enums;
using RideSharing.Domain.Trips.Validations;
using RideSharing.Domain.Trips.ValueObjects;

namespace RideSharing.Domain.Trips
{

    public class Trip : AggregateRoot
    {
        protected Trip() { }

        protected Trip(Customer customer, TripLocation tripLocation)
        {
            Customer = customer;
            TripLocation = tripLocation;
            TripDate = new TripDate();
            Status = TripStatusType.InProgress;
        }

        public Guid CustomerId { get; private set; }
        public Customer Customer { get; }
        public TripLocation TripLocation { get; }
        public TripDate TripDate { get; }
        public TripRating TripRating { get; private set; }

        public Guid DriverCarId { get; private set; }
        public DriverCar DriverCar { get; private set; }
        public TripStatusType Status { get; private set; }


        public void UpdateStartLocation(Location startLocation)
        {
            if (startLocation is null)
            {
                throw new ArgumentNullException(nameof(startLocation));
            }

            TripLocation.UpdateStartLocation(startLocation);
        }
        public void UpdateEndtLocation(Location endLocation)
        {
            if (endLocation is null)
            {
                throw new ArgumentNullException(nameof(endLocation));
            }

            TripLocation.UpdateStartLocation(endLocation);
        }

        public static Trip Create(Customer customer, TripLocation tripLocation)
        {
            var trip = new Trip(customer, tripLocation);

            trip.Validate<Trip, TripValidator>();

            trip.AddDomainEvent(new TripCreatedEvent(customer, trip));

            return trip;

        }

        public void AssignToDriver(DriverCar driverCar)
        {
            switch (Status)
            {
                case TripStatusType.Completed:
                    throw new InvalidOperationException(nameof(TripStatusType.Completed));
                case TripStatusType.Cancelled:
                    throw new InvalidOperationException(nameof(TripStatusType.Cancelled));
                case TripStatusType.InProgress:
                    throw new InvalidOperationException(nameof(TripStatusType.InProgress));
            }

            DriverCar = driverCar;
        }
        public void Start()
        {

            switch (Status)
            {
                case TripStatusType.Completed:
                    throw new InvalidOperationException(nameof(TripStatusType.Completed));
                case TripStatusType.Cancelled:
                    throw new InvalidOperationException(nameof(TripStatusType.Cancelled));
                case TripStatusType.InProgress:
                    throw new InvalidOperationException(nameof(TripStatusType.InProgress));
            }

            TripDate.TripStarted();

            AddDomainEvent(new TripStartedEvent(this));

        }
        public void Cancel()
        {
            switch (Status)
            {
                case TripStatusType.Completed:
                    throw new InvalidOperationException(nameof(TripStatusType.Completed));
                case TripStatusType.Cancelled:
                    throw new InvalidOperationException(nameof(TripStatusType.Cancelled));
            }

            Status = TripStatusType.Cancelled;
        }
        public void Complete()
        {
            switch (Status)
            {
                case TripStatusType.Requested:
                    throw new InvalidOperationException(nameof(TripStatusType.Requested));
                case TripStatusType.Completed:
                    throw new InvalidOperationException(nameof(TripStatusType.Completed));
                case TripStatusType.Cancelled:
                    throw new InvalidOperationException(nameof(TripStatusType.Cancelled));
            }

            Status = TripStatusType.Completed;
            TripDate.TripEnded();
            TripRating = new TripRating();

            AddDomainEvent(new TripCompletedEvent(this));
        }
        public void UpdateCustomerRating(int rating)
        {
            TripRating.UpdateCustomerRating(rating);
        }
        public void UpdateDriverRating(int rating)
        {
            TripRating.UpdateDriverRating(rating);
        }


    }
}
