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

            RuleFor(l => l.Landmark).NotEmpty().WithMessage("Landmark cannot be empty.")
                                    .NotNull().WithMessage("Landmark cannot be null.");

            RuleFor(l => l.LandmarkCity).NotEmpty().WithMessage("LandmarkCity cannot be empty.")
                                        .NotNull().WithMessage("LandmarkCity cannot be null.");

            RuleFor(l => l.LandmarkState).NotEmpty().WithMessage("LandmarkState cannot be empty.")
                                         .NotNull().WithMessage("LandmarkState cannot be null.");

            RuleFor(l => l.LandmarkName).NotEmpty().WithMessage("LandmarkName cannot be empty.")
                                        .NotNull().WithMessage("LandmarkName cannot be null.");

            RuleFor(l => l.City).NotEmpty().WithMessage("City cannot be empty.")
                                           .NotNull().WithMessage("City cannot be null.");

            RuleFor(l => l.Country).NotEmpty().WithMessage("Landmark cannot be empty.")
                                   .NotNull().WithMessage("Landmark cannot be null.");
        }
    }
}
