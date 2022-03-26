using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RideSharing.Abstractions.Repositories;
using System.Reflection;

namespace RideSharing.Abstractions
{
    public static class DependencyInjections
    {

        public static IServiceCollection AddAbstraction(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<,>));

            services.AddMediatR(Assembly.GetCallingAssembly());

            return services;


        }
    }
}
