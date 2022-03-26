using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Customers;
using RideSharing.Domain.Drivers;
using RideSharing.Domain.Locations;
using RideSharing.Domain.Trips.Enums;
using RideSharing.Domain.Trips.ValueObjects;

namespace RideSharing.Domain.Trips
{

    public class Trip
    {
        public Trip(Customer customer, Location startLocation, Location endLoaciton)
        {
            Customer = customer;
            TripLocation = new TripLocation(startLocation, endLoaciton);
            TripDate = new TripDate();
            Status = TripStatusType.InProgress;
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
            if (driver is null)
            {
                throw new ArgumentNullException(nameof(driver));
            }

            Driver = driver;
            Car = driver.Car;
        }
        public void Start()
        {
            if (Status == TripStatusType.Completed)
            {
                throw new InvalidOperationException(nameof(TripStatusType.Completed));
            }

            if (Status == TripStatusType.Cancelled)
            {
                throw new InvalidOperationException(nameof(TripStatusType.Cancelled));
            }

            TripDate.TripStarted();
        }
        public void Cancel()
        {
            if (Status == TripStatusType.Completed)
            {
                throw new InvalidOperationException(nameof(TripStatusType.Completed));
            }

            Status = TripStatusType.Cancelled;
        }
        public void Complete()
        {
            if (Status == TripStatusType.Cancelled)
            {
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
