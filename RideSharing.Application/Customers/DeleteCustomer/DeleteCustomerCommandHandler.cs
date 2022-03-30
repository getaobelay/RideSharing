using MediatR;
using RideSharing.Abstractions.Commands;
using RideSharing.Domain.Customers;
using RideSharing.Infrastructure.Repositories;

namespace RideSharing.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand, CustomerDto>
    {
        private readonly ICustmerRepository _custmerRepository;

        public DeleteCustomerCommandHandler(ICustmerRepository custmerRepository)
        {
            _custmerRepository = custmerRepository ?? throw new ArgumentNullException(nameof(custmerRepository));
        }

        public async Task<CustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {

            await _custmerRepository.Delete(request.Id);
            await _custmerRepository.SaveChangesAsync();

            return new CustomerDto();
        }
    }
}