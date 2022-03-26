using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RideSharing.Abstractions.Repositories;
using RideSharing.Infrastructure.Context;
using System.Reflection;
using WarehouseManagementSystem.Infrastructure.Identity;

namespace WarehouseManagementSystem.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("CleanArchitectureDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                 .AddEntityFrameworkStores<ApplicationDbContext>();


            services.Scan(s => s.FromAssemblies(Assembly.GetExecutingAssembly())
                                .AddClasses(c => c.AssignableTo(typeof(IRepository<>)))
                                .AsImplementedInterfaces()
                                .WithScopedLifetime());


            return services;
        }
    }
}