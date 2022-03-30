namespace RideSharing.Api.Registrars
{
    public class UseMvcService : IUseApplicationBuilder
    {
        public void ConfigurePipelineComponents(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
