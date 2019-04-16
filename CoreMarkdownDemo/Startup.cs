using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore1
{
    public class Startup
    {

        public Startup(IConfiguration config)
        {
            //Settings isn't being used, but could be. This is one way to initialize
            //the settings from the config.
            Settings.WebApiUrl = config.GetValue<string>("WebApiUrl");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //framework services
            services.AddMvc();

            //application services
            services.AddTransient<IClock, Clock>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //NOTE: This method is not being run when the environment is Development. Instead, ConfigureDevelopment is run.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //These two settings reproduces a traditional web site behvior
            //If there's a default file, e.g. index.html, display it
            app.UseDefaultFiles();
            //If the URL points to a static file, display it
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{Id?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World Fallback!");
            });
        }

        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
        {
            //These two settings reproduces a traditional web site behvior
            //If there's a default file, e.g. index.html, display it
            app.UseDefaultFiles();
            //If the URL points to a static file, display it
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{Id?}");
            });

            //With MVC in place, this won't return anything
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World Startup Development!");
            });
        }

        public void ConfigureBlamo(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World Startup Blamo!");
            });
        }
    }
}
