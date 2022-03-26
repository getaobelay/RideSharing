using FluentValidation;

namespace RideSharing.Application.Customers.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(l => l.FirstName).NotEmpty().WithMessage("First name cannot be empty.")
                                 .NotNull().WithMessage("First name cannot be null.");

            RuleFor(l => l.LastName).NotEmpty().WithMessage("Last name cannot be empty.")
                                            .NotNull().WithMessage("Last name cannot be null.");

            RuleFor(l => l.Gender).NotEmpty().WithMessage("Gender cannot be empty.")
                                     .NotNull().WithMessage("Gender cannot be null.");


            RuleFor(l => l.Phone).NotEmpty().WithMessage("Phone cannot be empty.")
                                     .NotNull().WithMessage("Phone cannot be null.");
        }
    }
}