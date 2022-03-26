using RideSharing.Domain.Common.Enums;

namespace RideSharing.Domain.Common
{

    public class Person
    {
        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public string Phone { get; private set; }

    }
}