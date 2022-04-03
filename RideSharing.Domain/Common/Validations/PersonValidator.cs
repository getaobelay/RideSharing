using FluentValidation;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Common;

namespace RideSharing.Domain.Common.Validations
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(l => l.FirstName).NotEmpty().WithMessage("First name cannot be empty.")
                                       .NotNull().WithMessage("First name cannot be null.");

            RuleFor(l => l.LastName).NotEmpty().WithMessage("Last name cannot be empty.")
                                            .NotNull().WithMessage("Last name cannot be null.");

    


            RuleFor(l => l.Phone).NotEmpty().WithMessage("Phone cannot be empty.")
                                     .NotNull().WithMessage("Phone cannot be null.");

        }
    }
}

