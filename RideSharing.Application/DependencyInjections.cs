using Microsoft.Extensions.DependencyInjection;
using RideSharing.Abstractions;

namespace RideSharing.Application
{
    public static class DependencyInjections
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAbstraction();

            return services;


        }
    }
}
