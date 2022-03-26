using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharing.Domain.Locations
{
    public class Location
    {
        private Location() { }
        internal Location(string latitude, string longitude, string landmark, string landmarkCity, string landmarkState, string landmarkName, string city, string country)
        {
            if (string.IsNullOrWhiteSpace(latitude))
            {
                throw new ArgumentException($"'{nameof(latitude)}' cannot be null or empty.", nameof(latitude));
            }

            if (string.IsNullOrWhiteSpace(longitude))
            {
                throw new ArgumentException($"'{nameof(longitude)}' cannot be null or empty.", nameof(longitude));
            }

            if (string.IsNullOrWhiteSpace(landmark))
            {
                throw new ArgumentException($"'{nameof(landmark)}' cannot be null or empty.", nameof(landmark));
            }

            if (string.IsNullOrWhiteSpace(landmarkCity))
            {
                throw new ArgumentException($"'{nameof(landmarkCity)}' cannot be null or empty.", nameof(landmarkCity));
            }

            if (string.IsNullOrWhiteSpace(landmarkState))
            {
                throw new ArgumentException($"'{nameof(landmarkState)}' cannot be null or empty.", nameof(landmarkState));
            }

            if (string.IsNullOrWhiteSpace(landmarkName))
            {
                throw new ArgumentException($"'{nameof(landmarkName)}' cannot be null or empty.", nameof(landmarkName));
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException($"'{nameof(city)}' cannot be null or empty.", nameof(city));
            }

            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentException($"'{nameof(country)}' cannot be null or empty.", nameof(country));
            }

            Latitude = latitude;
            Longitude = longitude;
            Landmark = landmark;
            LandmarkCity = landmarkCity;
            LandmarkState = landmarkState;
            LandmarkName = landmarkName;
            City = city;
            Country = country;
        }

        public Guid Id { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public string Landmark { get; private set; }
        public string LandmarkCity { get; private set; }
        public string LandmarkState { get; private set; }
        public string LandmarkName { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }


    }
}
