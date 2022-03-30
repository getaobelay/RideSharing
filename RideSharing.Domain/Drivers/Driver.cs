using RideSharing.Abstractions.Domain;
using RideSharing.Abstractions.Extensions;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Common;
using RideSharing.Domain.Drivers.Validations;

namespace RideSharing.Domain.Drivers
{
    public sealed class Driver : AggregateRoot
    {

        private Driver() { }

        internal Driver(Person person, string licenseNo)
        {

            Person = person;
            LicenseNo = licenseNo;
            CreatedAt = DateTime.UtcNow;

            this.Validate<Driver, DriverValidator>();
        }


        public Person Person { get; private set; }
        public string LicenseNo { get; private set; }
        public DateTime CreatedAt { get; }
        public Guid DriverCarId { get; private set; }
        private readonly List<DriverCar> _driverCars = new();
        public IReadOnlyCollection<DriverCar> DriverCars => _driverCars.AsReadOnly();



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


        public void AddCar(Car car, string licensePlate)
        {
            if (car is null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            if (licensePlate is null)
            {
                throw new ArgumentNullException(nameof(licensePlate));
            }

            var driverCar = new DriverCar(this, car, licensePlate);

            _driverCars.Add(driverCar);
        }

    }
}