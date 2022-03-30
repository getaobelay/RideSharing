using RideSharing.Abstractions.Repositories;
using RideSharing.Domain.Customers;
using RideSharing.Domain.Drivers;
using RideSharing.Domain.Trips;
using RideSharing.Infrastructure.Context;

namespace RideSharing.Infrastructure.Repositories
{
    public interface ITripRepository : IRepository<Trip>
    {
    }

    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}