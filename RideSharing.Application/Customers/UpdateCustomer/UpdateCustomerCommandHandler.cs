using MediatR;
using RideSharing.Abstractions.Commands;
using RideSharing.Domain.Customers;
using RideSharing.Infrastructure.Repositories;

namespace RideSharing.Application.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, CustomerDto>
    {
        private readonly ICustmerRepository _custmerRepository;

        public UpdateCustomerCommandHandler(ICustmerRepository custmerRepository)
        {
            _custmerRepository = custmerRepository ?? throw new ArgumentNullException(nameof(custmerRepository));
        }

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {

            var customer = await _custmerRepository.GetByIdAsync(request.Id);

            if (customer is null)
            {
                throw new ArgumentException(nameof(customer));
            }


            customer.PersonInfo.UpdateName(request.FirstName, request.LastName, request.MiddleName);
            customer.PersonInfo.UpdateContact(request.Phone, request.Email);

            _custmerRepository.Update(customer);

            await _custmerRepository.SaveChangesAsync();

            return new CustomerDto();
        }
    }
}