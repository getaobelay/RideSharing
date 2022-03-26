using RideSharing.Domain.Cars;
using RideSharing.Domain.Common;

namespace RideSharing.Domain.Drivers
{
    public class Driver
    {
        private Driver() { }

        internal Driver(Person person, Car car, string licenseNo)
        {
            Person = person;
            LicenseNo = licenseNo;
            CreatedAt = DateTime.UtcNow;
            Car = car;
        }


        public Person Person { get; private set; }
        public string LicenseNo { get; private set; }
        public DateTime CreatedAt { get; }
        public Car Car { get; private set; }

        public void UpdatePerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            Person = person;
        }

        public void UpdateLicenseNo(string licenseNo)
        {
            if (licenseNo == null)
            {
                throw new ArgumentNullException(nameof(licenseNo));
            }

            LicenseNo = licenseNo;
        }

        public void UpdateCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            Car = car;
        }

    }
}