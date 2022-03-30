using RideSharing.Api.Options;
using RideSharing.Api.Registrars;

namespace RideSharing.Api.Registrars
{
    public class AddSwaggerService : IAddServiceCollection
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.ConfigureOptions<ConfigureSwaggerOptions>();
        }
    }
}
