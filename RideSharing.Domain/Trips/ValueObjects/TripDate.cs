using RideSharing.Domain.Trips;
namespace RideSharing.Domain.Trips.ValueObjects
{
    public class TripDate
    {
        internal TripDate()
        {
            RequestdTimestamp = DateTime.UtcNow;
        }

        public DateTime RequestdTimestamp { get; }
        public DateTime StartTimestamp { get; private set; }
        public DateTime EndTimestamp { get; private set; }
        public TimeSpan WaitTime { get; private set; }


        public void TripStarted()
        {
            StartTimestamp = DateTime.UtcNow;
            WaitTime = RequestdTimestamp.Subtract(StartTimestamp);
        }

        public void TripEnded()
        {
            EndTimestamp = DateTime.UtcNow;
        }
    }
}
