using FluentValidation;
using RideSharing.Domain.Trips;
using RideSharing.Domain.Trips.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharing.Domain.Trips.Validations
{
    public class TripLocationValidator : AbstractValidator<TripLocation>
    {
        public TripLocationValidator()
        {
            RuleFor(l => l.StartLocation).NotEmpty().WithMessage("Start location cannot be empty.")
                                        .NotNull().WithMessage("Start location cannot be null.");

            RuleFor(l => l.EndLocation).NotEmpty().WithMessage("End location cannot be empty.")
                                     .NotNull().WithMessage("End location cannot be null.");

        }
    }
}
