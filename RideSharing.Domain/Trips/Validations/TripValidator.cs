using FluentValidation;
using RideSharing.Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharing.Domain.Trips.Validations
{
    public class TripValidator : AbstractValidator<Trip>
    {
        public TripValidator()
        {
            RuleFor(l => l.TripLocation).NotEmpty().WithMessage("Trip location cannot be empty.")
                                        .NotNull().WithMessage("Trip location cannot be null.");

            RuleFor(l => l.Customer).NotEmpty().WithMessage("Customer cannot be empty.")
                                     .NotNull().WithMessage("Customer cannot be null.");

        }
    }
}
