using RideSharing.Abstractions.Extensions;
using RideSharing.Domain.Common.Validations;
using RideSharing.Shared.Enums;

namespace RideSharing.Domain.Common
{

    public class Person
    {
        private Person() { }
        protected Person(string firstName, string lastName, string middleName, string phone, string email, Gender gender, DateTime dateOfBirth)
        {
            Gender = gender;
            DateOfBirth = dateOfBirth;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Email = email;
            Phone = phone;
        }

        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        public static Person Create(string firstName, string lastName, string middleName, string phone, string email, Gender gender, DateTime dateOfBirth)
        {
            var person = new Person(firstName, lastName, middleName, phone, email, gender, dateOfBirth);

            return person.Validate<Person, PersonValidator>();
        }

        public void UpdateName(string firstName, string lastName, string middleName)
        {

            if (FirstName != firstName && !string.IsNullOrWhiteSpace(firstName))
                FirstName = firstName;

            if (LastName != lastName && !string.IsNullOrWhiteSpace(lastName))
                FirstName = firstName;

            if (MiddleName != middleName && !string.IsNullOrWhiteSpace(middleName))
                FirstName = firstName;

        }

        public void UpdateContact(string phone, string email)
        {
            if (Phone != phone && !string.IsNullOrWhiteSpace(phone))
                Phone = phone;

            if (Email != email && !string.IsNullOrWhiteSpace(email))
                Email = email;

        }


    }


}