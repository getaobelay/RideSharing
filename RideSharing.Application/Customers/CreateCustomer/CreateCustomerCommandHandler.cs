using MediatR;
using RideSharing.Abstractions.Commands;
using RideSharing.Application.Customers.Dtos;
using RideSharing.Domain.Customers;
using RideSharing.Infrastructure;

namespace RideSharing.Application.Customers.CreateCustomer
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustmerRepository _custmerRepository;

        public CreateCustomerCommandHandler(ICustmerRepository custmerRepository)
        {
            _custmerRepository = custmerRepository ?? throw new ArgumentNullException(nameof(custmerRepository));
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.FirstName,
                                           request.LastName,
                                           request.MiddleName,
                                           request.Phone,
                                           request.Gender,
                                           request.DateOfBirth);

            await _custmerRepository.AddAsync(customer);
            await _custmerRepository.SaveChangesAsync();

            return new CustomerDto();
        }
    }
}