using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using RideSharing.Api.Filters;
using RideSharing.Api.Registrars;

namespace RideSharing.Api.Registrars
{
    public class AddAutofacService : IAddServiceCollection
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
                options.Filters.Add(typeof(ExceptionHandler));
            }).AddNewtonsoftJson();

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            services.AddVersionedApiExplorer(conifg =>
            {
                conifg.GroupNameFormat = "'v'VVV";
                conifg.SubstituteApiVersionInUrl = true;
            });

            services.AddEndpointsApiExplorer();
        }
    }
}
