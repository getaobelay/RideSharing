using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace RideSharing.Api.Registrars
{
    public class UseSwaggerService : IUseApplicationBuilder
    {
        public void ConfigurePipelineComponents(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.ApiVersion.ToString());
                }
            });
        }
    }
}
