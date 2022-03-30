using FluentValidation;

namespace RideSharing.Application.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(l => l.Id).NotNull().WithMessage("Customer  id cannot be null.")
                              .NotEqual(Guid.Empty).WithMessage("Customer id cannot be empty.");

        }
    }
}