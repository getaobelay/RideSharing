using FluentValidation;
using RideSharing.Domain.Locations.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideSharing.Abstractions.Domain;
using RideSharing.Abstractions.Extensions;

namespace RideSharing.Domain.Locations
{
    public class Location : Entity
    {

        private Location() { }
        internal Location(string latitude, string longitude, string landmark, string landmarkCity, string landmarkState, string landmarkName, string city, string country)
        {


            Latitude = latitude;
            Longitude = longitude;
            Landmark = landmark;
            LandmarkCity = landmarkCity;
            LandmarkState = landmarkState;
            LandmarkName = landmarkName;
            City = city;
            Country = country;

            this.Validate<Location, LocationValidator>();
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
