using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideSharing.Domain.Trips;

namespace RideSharing.Domain.Trips.Enums
{
    public enum TripStatusType
    {
        Cancelled = 0,
        InProgress = 1,
        Completed = 2
    }
}
