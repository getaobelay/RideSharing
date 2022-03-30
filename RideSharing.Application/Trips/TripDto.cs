using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideSharing.Application.Trips
{
    public class TripDto
    {
        public string CustomerName { get; set; }
        public DateTime RequestdTimestamp { get; set; }
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public string Status { get; set; }

    }
}
