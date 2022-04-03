using AutoMapper;
using MediatR;
using RideSharing.Abstractions.Commands;
using RideSharing.Domain.Customers;
using RideSharing.Infrastructure.Repositories;
using RideSharing.Shared;

namespace RideSharing.Application.Customers.CreateCustomer
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Result<CustomerDto>>
    {
        private readonly ICustmerRepository _custmerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustmerRepository custmerRepository)
        {
            _custmerRepository = custmerRepository ?? throw new ArgumentNullException(nameof(custmerRepository));
        }

        public async Task<Result<CustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            var customer = Customer.Create(request.FirstName,
                                           request.LastName,
                                           request.MiddleName,
                                           request.Phone,
                                           request.Email,
                                           request.Gender,
                                           request.DateOfBirth);

            await _custmerRepository.AddAsync(customer);
            await _custmerRepository.SaveChangesAsync(cancellationToken);

            return new Result<CustomerDto>();
        }
    }
}