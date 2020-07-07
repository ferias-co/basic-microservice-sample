using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            
            ServicesConfig.Usecases(services);
            ServicesConfig.Controllers(services);
            ServicesConfig.Gateways(services);
            ServicesConfig.Drivers(services);
            
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
