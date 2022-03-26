using RideSharing.Abstractions.Repositories;
using RideSharing.Domain.Customers;
using RideSharing.Infrastructure.Context;

namespace RideSharing.Infrastructure
{
    public interface ICustmerRepository : IRepository<Customer>
    {
    }

    public class CustmerRepository : Repository<ApplicationDbContext, Customer>, ICustmerRepository
    {
        public CustmerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}