using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Customers;
using RideSharing.Domain.Drivers;
using RideSharing.Domain.Trips;
using RideSharing.Infrastructure.Identity;
using System.Reflection;

namespace RideSharing.Infrastructure.Context
{
    internal interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; }
        DbSet<Trip> Trips { get; }
        DbSet<Car> Cars { get; }
        DbSet<Driver> Drivers { get; }
        DbSet<DriverCar> DriverCars { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }

    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IDateTime dateTime) : base(options, operationalStoreOptions)
        {
            _dateTime = dateTime;
        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Trip> Trips => Set<Trip>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<DriverCar> DriverCars => Set<DriverCar>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}