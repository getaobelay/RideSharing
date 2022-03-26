using RideSharing.Abstractions.Domain;
using RideSharing.Abstractions.Extensions;
using RideSharing.Domain.Cars;
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

        internal Trip(Customer customer, TripLocation tripLocation)
        {
            Customer = customer;
            TripLocation = tripLocation;
            TripDate = new TripDate();
            Status = TripStatusType.InProgress;

            this.Validate<Trip, TripValidator>();
        }

        public Guid Id { get; }
        public Guid DriverId { get; }
        public Driver Driver { get; private set; }
        public Guid CarId { get; }
        public Car Car { get; private set; }
        public Guid CustomerId { get; }
        public Customer Customer { get; }
        public TripLocation TripLocation { get; }
        public TripDate TripDate { get; }
        public TripRating TripRating { get; private set; }
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
        public void AssignToDriver(Driver driver)
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

            Driver = driver;
            Car = driver.CurrentCar;
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
