using FluentValidation;
using RideSharing.Domain.Customers;

namespace RideSharing.Domain.Customers.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(l => l.Person).NotEmpty().WithMessage("Person cannot be empty.")
                                     .NotNull().WithMessage("LicenseNo cannot be null.");
        }
    }
}
