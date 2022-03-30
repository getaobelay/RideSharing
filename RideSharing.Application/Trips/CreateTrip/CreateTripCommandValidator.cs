using FluentValidation;

namespace RideSharing.Application.Trips.CreateTrip
{
    public class CreateTripCommandValidator : AbstractValidator<CreateTripCommand>
    {
        public CreateTripCommandValidator()
        {
            RuleFor(c => c.Origin).NotNull().WithMessage("Origin location  cannot be null.")
                                         .NotEmpty().WithMessage("Origin location cannot be empty.");

            RuleFor(c => c.Destination).NotNull().WithMessage("Destination location  cannot be null.")
                                       .NotEmpty().WithMessage("Destination location cannot be empty.");


        }
    }
}