using AutoMapper;
using MediatR;
using RideSharing.Abstractions.Commands;
using RideSharing.Domain.Customers;
using RideSharing.Domain.Trips;
using RideSharing.Infrastructure.Repositories;
using RideSharing.Infrastructure.Services;

namespace RideSharing.Application.Trips.CreateTrip
{
    public class CreateTripCommandHandler : ICommandHandler<CreateTripCommand, TripDto>
    {
        private readonly ICustmerRepository _custmerRepository;
        private readonly IGeoLocationService _geoLocationService;
        private readonly IMapper _mapper;

        public CreateTripCommandHandler(ICustmerRepository custmerRepository, IMapper mapper, IGeoLocationService geoLocationService)
        {
            _custmerRepository = custmerRepository ?? throw new ArgumentNullException(nameof(custmerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _geoLocationService = geoLocationService ?? throw new ArgumentNullException(nameof(geoLocationService));
        }

        public async Task<TripDto> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {

            var customer = await _custmerRepository.GetByIdAsync(request.CustomerId);

            if (customer is null)
            {
                throw new ArgumentException(nameof(customer));
            }

            var originLocation = await _geoLocationService.GetLocation(request.Origin);
            var destinationLocation = await _geoLocationService.GetLocation(request.Destination);

            var tripLocation = TripLocation.Create(originLocation, destinationLocation);

            var trip = Trip.Create(customer, tripLocation);

            customer.AddTrip(trip);

            await _custmerRepository.SaveChangesAsync();

            return _mapper.Map<TripDto>(trip);
        }
    }
}