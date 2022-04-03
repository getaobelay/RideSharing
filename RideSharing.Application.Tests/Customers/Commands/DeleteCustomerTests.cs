using FluentAssertions;
using NUnit.Framework;
using RideSharing.Application.Customers.DeleteCustomer;
using RideSharing.Domain.Customers;

namespace RideSharing.Application.Tests.Customers.Commands;
using static Testing;

public class DeleteCustomerTests : TestBase
{


    [Test]
    public async Task ShouldNotDeleteWhenCommandIsNotValid()
    {
        var command = new DeleteCustomerCommand();

        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task ShoulDeleteWhenCommandIsValid()
    {

        var customer = CustomerTestData.GetCustomers().First();



        await AddAsync(customer);

        var command = new DeleteCustomerCommand { Id = customer.Id };

        var result = await SendAsync(command);

        var deleted = await FindAsync<Customer>(customer.Id);

        deleted.Should().BeNull();
    }
}