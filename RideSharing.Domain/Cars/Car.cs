using RideSharing.Abstractions.Extensions;
using RideSharing.Domain.Cars.Validations;
using RideSharing.Domain.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharing.Domain.Cars
{
    public class Car
    {

        public Guid Id { get; private set; }
        public Guid DriverId { get; private set; }

        public readonly List<Driver> _drivers = new();

        public Car(string manufacture, string model, string licensePlateNo)
        {
            Manufacture = manufacture;
            Model = model;
            LicensePlateNo = licensePlateNo;

            this.Validate<Car, CarValidator>();
        }

        public IReadOnlyCollection<Driver> Drivers => _drivers.AsReadOnly();
        public string Manufacture { get; private set; }
        public string Model { get; private set; }
        public string LicensePlateNo { get; private set; }

    }
}
