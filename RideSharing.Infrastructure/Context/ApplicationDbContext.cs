using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RideSharing.Domain.Cars;
using RideSharing.Domain.Customers;
using RideSharing.Domain.Drivers;
using RideSharing.Domain.Trips;
using System.Reflection;

namespace RideSharing.Infrastructure.Context;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Driver> Drivers { get; set; }


    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

}