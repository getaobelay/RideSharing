using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharing.Domain.Locations.Validations
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(l => l.Latitude).NotEmpty().WithMessage("Latitude cannot be empty.")
                                    .NotNull().WithMessage("Latitude cannot be null.");

            RuleFor(l => l.Longitude).NotEmpty().WithMessage("Longitude cannot be empty.")
                                     .NotNull().WithMessage("Longitude cannot be null.");

            RuleFor(l => l.AddressLine).NotEmpty().WithMessage("Addressline cannot be empty.")
                                    .NotNull().WithMessage("Addressline cannot be null.");

        }
    }
}
