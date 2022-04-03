using Bogus;
using RideSharing.Application.Tests;
using RideSharing.Domain.Customers;

namespace RideSharing.Application.Tests.Customers
{
    internal static class CustomerTestData
    {
        public static List<Customer> GetCustomers()
        {
            Faker<Customer> customerGenerator = new Faker<Customer>()
                       .UsePrivateConstructor()
                       .RuleFor(c => c.Id, Guid.NewGuid())
                       .RuleFor(c => c.PersonInfo, GetPersonInfo());


            return customerGenerator.Generate(5);
        }

        public static Domain.Common.Person GetPersonInfo()
        {
            Faker<Domain.Common.Person> personInfoGenerator = new Faker<Domain.Common.Person>()
                .UsePrivateConstructor()
                .RuleFor(c => c.FirstName, bogus => bogus.Name.FirstName())
                .RuleFor(c => c.MiddleName, bogus => bogus.Name.FirstName())
                .RuleFor(c => c.LastName, bogus => bogus.Name.LastName())
                .RuleFor(c => c.Phone, bogus => bogus.Phone.Locale)
                .RuleFor(c => c.Gender, Shared.Enums.Gender.Male)
                .RuleFor(c => c.DateOfBirth, DateTime.Now)
                .RuleFor(c => c.Email, bogus => bogus.Person.Email);

            return personInfoGenerator.Generate(1).First();

        }

    }
}