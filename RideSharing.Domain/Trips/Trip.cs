using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Customers;
using RideSharing.Domain.Drivers;
using RideSharing.Domain.Trips.Enums;
using RideSharing.Domain.Trips.ValueObjects;

namespace RideSharing.Domain.Trips
{

    public class Trip
    {
        public Guid Id { get; set; }
        public Guid DriverId { get; set; }
        public Driver Driver { get; private set; }
        public Guid CarId { get; set; }
        public Car Car { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; set; }
        public TripLocation TripLocation { get; private set; }
        public TripDate TripDate { get; set; }
        public TripRating TripRating { get; private set; }
        public TripStatusType Status { get; private set; }


    }
}
