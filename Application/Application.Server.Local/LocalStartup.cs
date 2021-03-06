using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Server.Local
{
    public class LocalStartup : Startup
    {
        protected override void RegisterServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        protected override void ConfigureRegisteredServices(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseWebAssemblyDebugging();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
        }

        protected override void ConfigureEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapRazorPages();
            base.ConfigureEndpoints(endpoints);
            endpoints.MapFallbackToFile("index.html");
        }
    }
}
