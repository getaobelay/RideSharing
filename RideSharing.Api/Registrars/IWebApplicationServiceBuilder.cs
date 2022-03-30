namespace RideSharing.Api.Registrars
{
    public interface IRegistrar
    {
    }

    public interface IWebApplicationBuilder : IRegistrar
    {
        public void ConfigurePipelineComponents(WebApplication app);
    }

    public interface IWebApplicationServiceBuilder : IRegistrar
    {
        public void ConfigureServices(WebApplicationBuilder builder);
    }

    public interface IUseApplicationBuilder : IRegistrar
    {
        public void ConfigurePipelineComponents(IApplicationBuilder app);
    }

    public interface IAddServiceCollection : IRegistrar
    {
        public void ConfigureServices(IServiceCollection services);
    }
}
