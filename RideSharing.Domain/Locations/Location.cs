using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharing.Domain.Locations
{
    public class Location
    {
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
