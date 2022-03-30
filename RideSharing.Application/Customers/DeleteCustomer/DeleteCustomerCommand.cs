using MediatR;
using RideSharing.Abstractions.Commands;
using RideSharing.Shared.Enums;

namespace RideSharing.Application.Customers.DeleteCustomer
{
    public record DeleteCustomerCommand : ICommandRequest<CustomerDto>
    {
        public Guid Id { get; set; }
    }
}