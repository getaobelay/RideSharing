using RideSharing.Abstractions.Extensions;
using RideSharing.Domain.Common.Enums;
using RideSharing.Domain.Common.Validations;

namespace RideSharing.Domain.Common
{

    public class Person
    {
        public Person(Gender gender, DateTime dateOfBirth, string firstName, string lastName, string middleName, string phone)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException($"'{nameof(firstName)}' cannot be null or empty.", nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty.", nameof(lastName));
            }

            if (string.IsNullOrWhiteSpace(middleName))
            {
                throw new ArgumentException($"'{nameof(middleName)}' cannot be null or empty.", nameof(middleName));
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException($"'{nameof(phone)}' cannot be null or empty.", nameof(phone));
            }

            Gender = gender;
            DateOfBirth = dateOfBirth;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Phone = phone;

            this.Validate<Person, PersonValidator>();
        }

        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public string Phone { get; private set; }

    }


}