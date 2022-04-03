using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RideSharing.Abstractions.Repositories;
using RideSharing.Infrastructure.Context;
using RideSharing.Infrastructure.Identity;
using RideSharing.Infrastructure.Services;
using System.Reflection;

namespace RideSharing.Infrastructure
{
    public static class DependecyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("RideSharing"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }



            services.AddSingleton<IGeoLocationService, GeoLocationService>();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<IDateTime, DateTimeService>();



            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryClients(Config.GetClients())
                .AddAspNetIdentity<ApplicationUser>();

            builder.AddDeveloperSigningCredential();

            //services.AddAuthorization(options =>
            //    options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));


            services.Scan(s => s.FromAssemblies(Assembly.GetExecutingAssembly())
                                    .AddClasses(c => c.AssignableTo(typeof(IRepository<>)))
                                    .AsImplementedInterfaces()
                                    .WithScopedLifetime());


            return services;
        }
    }
}