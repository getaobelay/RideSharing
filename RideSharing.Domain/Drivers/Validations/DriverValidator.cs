using FluentValidation;

namespace RideSharing.Domain.Drivers.Validations
{
    public class DriverValidator : AbstractValidator<Driver>
    {
        public DriverValidator()
        {
            RuleFor(l => l.LicenseNo).NotEmpty().WithMessage("LicenseNo cannot be empty.")
                                     .NotNull().WithMessage("LicenseNo cannot be null.");

            RuleFor(l => l.Person).NotEmpty().WithMessage("Person cannot be empty.")
                                    .NotNull().WithMessage("Person cannot be null.");
        }
    }
}
