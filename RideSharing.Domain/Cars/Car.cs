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
            if (string.IsNullOrWhiteSpace(manufacture))
            {
                throw new ArgumentException($"'{nameof(manufacture)}' cannot be null or empty.", nameof(manufacture));
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException($"'{nameof(model)}' cannot be null or empty.", nameof(model));
            }

            if (string.IsNullOrWhiteSpace(licensePlateNo))
            {
                throw new ArgumentException($"'{nameof(licensePlateNo)}' cannot be null or empty.", nameof(licensePlateNo));
            }

            Manufacture = manufacture;
            Model = model;
            LicensePlateNo = licensePlateNo;
        }

        public IReadOnlyCollection<Driver> Drivers => _drivers.AsReadOnly();
        public string Manufacture { get; private set; }
        public string Model { get; private set; }
        public string LicensePlateNo { get; private set; }

    }
}
