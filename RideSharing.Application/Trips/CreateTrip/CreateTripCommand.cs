using MediatR;
using RideSharing.Abstractions.Commands;
using RideSharing.Domain.Locations;
using RideSharing.Shared.Enums;

namespace RideSharing.Application.Trips.CreateTrip
{
    public record CreateTripCommand : ICommandRequest<TripDto>
    {

        public Guid CustomerId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }


    }
}