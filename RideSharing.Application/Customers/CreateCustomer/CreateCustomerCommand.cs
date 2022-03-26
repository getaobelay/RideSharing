using MediatR;
using RideSharing.Abstractions.Commands;
using RideSharing.Application.Customers.Dtos;
using RideSharing.Shared.Enums;

namespace RideSharing.Application.Customers.CreateCustomer
{
    public record CreateCustomerCommand : ICommandRequest<CustomerDto>
    {
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
    }
}