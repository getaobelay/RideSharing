namespace RideSharing.Infrastructure
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}