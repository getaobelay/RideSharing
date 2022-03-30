using RideSharing.Abstractions.Repositories;
using RideSharing.Domain.Customers;
using RideSharing.Domain.Trips;
using RideSharing.Infrastructure.Context;

namespace RideSharing.Infrastructure.Repositories
{
    public interface IDriverRepository : IRepository<Customer>
    {
    }

    public class DriverRepository : Repository<Customer>, IDriverRepository
    {
        public DriverRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}