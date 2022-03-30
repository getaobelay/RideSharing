using MediatR;
using RideSharing.Abstractions.Commands;
using RideSharing.Shared.Enums;

namespace RideSharing.Application.Customers.UpdateCustomer
{
    public record UpdateCustomerCommand : ICommandRequest<CustomerDto>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}