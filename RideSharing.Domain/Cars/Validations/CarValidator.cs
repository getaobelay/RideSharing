using FluentValidation;
using RideSharing.Domain.Cars;

namespace RideSharing.Domain.Cars.Validations
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(l => l.Manufacture).NotEmpty().WithMessage("Manufacture cannot be empty.")
                                       .NotNull().WithMessage("Manufacture cannot be null.");

            RuleFor(l => l.Model).NotEmpty().WithMessage("Model cannot be empty.")
                                            .NotNull().WithMessage("Model cannot be null.");

            RuleFor(l => l.LicensePlateNo).NotEmpty().WithMessage("License plate number cannot be empty.")
                                          .NotNull().WithMessage("License plate number cannot be null.");
        }
    }
}
