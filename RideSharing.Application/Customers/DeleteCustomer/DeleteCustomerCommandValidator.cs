using FluentValidation;

namespace RideSharing.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(l => l.Id).NotNull().WithMessage("Customer id cannot be null.")
                              .NotEqual(Guid.Empty).WithMessage("Customer id cannot be empty.");

        }
    }
}