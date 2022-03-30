using RideSharing.Api.Registrars;

namespace RideSharing.Api.Extensions
{
    public static class RegistarExtensions
    {
        public static void RegisterServices(this IServiceCollection service, Type scanningType)
        {
            foreach (var registrar in GetRegistrars<IAddServiceCollection>(scanningType))
                registrar.ConfigureServices(service);
        }

        public static void RegisterApp(this IApplicationBuilder app, Type scanningType)
        {
            foreach (var registrar in GetRegistrars<IUseApplicationBuilder>(scanningType))
            {
                registrar.ConfigurePipelineComponents(app);
            }
        }

        private static IEnumerable<T> GetRegistrars<T>(Type scanningType) where T : IRegistrar
        {
            return scanningType.Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(T)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<T>();
        }
    }
}
