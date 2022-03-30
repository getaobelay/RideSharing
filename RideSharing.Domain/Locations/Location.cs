using FluentValidation;
using RideSharing.Domain.Locations.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideSharing.Abstractions.Domain;
using RideSharing.Abstractions.Extensions;
using RideSharing.Domain.Trips;

namespace RideSharing.Domain.Locations
{
    public class Location : Entity
    {

        private Location() { }
        private Location(double latitude, double longitude, string addressLine, string landmark, string postalCode, string country)
        {


            Latitude = latitude;
            Longitude = longitude;
            AddressLine = addressLine;
            Landmark = landmark;
            PostalCode = postalCode;
            Country = country;


            this.Validate<Location, LocationValidator>();
        }


        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string AddressLine { get; private set; }
        public string Landmark { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }

        public static Location Create(double latitude, double longitude, string addressLine, string landmark, string postalCode, string country)
        {
            return new Location(latitude, longitude, addressLine, landmark, postalCode, country);
        }
        public IReadOnlyCollection<TripLocation> StartLocations { get; set; }
        public IReadOnlyCollection<TripLocation> EndLocations { get; set; }

        public static object Create()
        {
            throw new NotImplementedException();
        }
    }
}
