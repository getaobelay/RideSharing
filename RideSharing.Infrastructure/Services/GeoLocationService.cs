using BingMapsRESTToolkit;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using RideSharing.Abstractions.Repositories;
using RideSharing.Domain.Trips;
using RideSharing.Infrastructure.Context;

namespace RideSharing.Infrastructure.Services
{
    public interface IGeoLocationService
    {
        Task<Domain.Locations.Location> GetLocation(string address);
    }

    public class GeoLocationService : IGeoLocationService
    {

        private const string ApiSecret = "Agjq8g05JT-mYPC269eC5S7I8AQC9CTGH3rfl1LEdufQJH02eX86yztNdg0l9FLE";

        public async Task<Domain.Locations.Location> GetLocation(string address)
        {
            var request = new GeocodeRequest()
            {
                Query = address,
                IncludeIso2 = true,
                IncludeNeighborhood = true,
                MaxResults = 25,
                BingMapsKey = ApiSecret
            };

            //Process the request by using the ServiceManager.
            var response = await request.Execute();

            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0 &&
                response.ResourceSets[0].Resources[0] != null
                )
            {
                var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;

                var coords = result.Point.Coordinates;

                var addressLine = result.Address.AddressLine;
                var country = result.Address.CountryRegion;
                var landmark = result.Address.Landmark;
                var postalCode = result.Address.PostalCode;
                return Domain.Locations.Location.Create(coords[0], coords[1], addressLine, landmark, postalCode, country);
            }

            throw new ArgumentNullException($"Geolocation not found for the address {address}");
        }

    }
}