//using FluentAssertions;
//using NUnit.Framework;
//using System;
//using System.Threading.Tasks;
//using WarehouseManagementSystem.Application.Customers.Commands;
//using WarehouseManagementSystem.Application.Customers.Responses;
//using WarehouseManagementSystem.Core.Common;
//using WarehouseManagementSystem.Core.Customers;

//using static WarehouseManagementSystem.Application.Tests.Testing;

//namespace WarehouseManagementSystem.Application.Tests.Customers.Commands;

//public class UpdateCustomerTests : TestBase
//{
//    [Test]
//    public async Task ShouldNotUpdateWhenCommandIsNotValid()
//    {
//        var command = new UpdateCustomerCommand();

//        var result = await SendAsync(command);

//        result.IsError.Should().BeTrue();
//        result.Errors.Should().NotBeEmpty();
//    }

//    [Test]
//    public async Task ShouldUpdateWhenCommandIsValid()
//    {
//        var personalInfo = Person.Create("gadi", "belay", DateTime.UtcNow);

//        var address = Address.Create("countrry", "sdasd", "dsadasdsa", "dsadasda", "dsadasda", "dsadada", "dsadasdasdsa");
//        var billingAddress = Address.Create("countrry", "sdasd", "dsadasdsa", "dsadasda", "dsadasda", "dsadada", "dsadasdasdsa");
//        var shipingAddress = Address.Create("countrry", "sdasd", "dsadasdsa", "dsadasda", "dsadasda", "dsadada", "dsadasdasdsa");
//        var customer = Customer.Create(personalInfo, CustomerAddresses.Create(address, billingAddress, shipingAddress));

//        await AddAsync(customer);

//        var updatedFirstName = "customerName";
//        var updatedLastName = "TestDiscription";
//        var updatedAddress = new AddressDto
//        {
//            AddressLine1 = "line1",
//            AddressLine2 = "line2",
//            AddressLine3 = "line3",
//            City = "City",
//            Country = "country",
//            PostalCode = "postal code",
//            Region = "region"
//        };

//        var command = new UpdateCustomerCommand
//        {
//            Id = customer.Id,
//            FirstName = updatedFirstName,
//            LastName = updatedLastName,
//            BirthDate = DateTime.UtcNow,
//            Address = updatedAddress,
//            ShippingAddress = updatedAddress,
//            BillingAddress = updatedAddress,
//        };

//        var result = await SendAsync(command);

//        //assert
//        result.IsError.Should().NotBe(true);
//        result.Errors.Should().BeEmpty();
//        result.Value.Should().NotBeNull();

//        var customerResult = await FindAsync<Customer>(customer.Id);

//        customerResult.PersonalInfo.FirstName.Should().Be(updatedFirstName);
//        customerResult.PersonalInfo.LastName.Should().Be(updatedLastName);
//    }
//}