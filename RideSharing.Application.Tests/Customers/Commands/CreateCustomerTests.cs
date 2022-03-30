using FluentAssertions;
using NUnit.Framework;
using RideSharing.Application.Customers.CreateCustomer;
using RideSharing.Domain.Customers;

namespace RideSharing.Application.Tests.Customers.Commands;
using static Testing;

public class CreateCustomerTests : TestBase
{
    [Test]
    public async Task ShouldNotCreateWhenCommandIsNotValid()
    {
        var command = new CreateCustomerCommand();

        var result = await SendAsync(command);
    }

    [Test]
    public async Task ShouldCreateWhenCommandIsValid()
    {

        var command = new CreateCustomerCommand
        {

            FirstName = "Customer1",
            LastName = "Customer2",
            Gender = Shared.Enums.Gender.Male,
            Email = "cusotmer1@email.com",
            MiddleName = "cusotmerName",
            Phone = "055-144-1442",
            DateOfBirth = DateTime.Now,
        };

        var result = await SendAsync(command);

    }
}