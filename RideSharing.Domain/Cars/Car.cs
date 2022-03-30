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
        public Car(string manufacture, string model)
        {
            Manufacture = manufacture;
            Model = model;

            this.Validate<Car, CarValidator>();
        }
        public string Manufacture { get; private set; }
        public string Model { get; private set; }

        public Guid DriverCarId { get; private set; }
        private readonly List<DriverCar> _driverCars = new();
        public IReadOnlyCollection<DriverCar> DriverCars => _driverCars.AsReadOnly();

    }
}
