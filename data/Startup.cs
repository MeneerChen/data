using System.Linq;
using data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace data
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHandleDataGeneration, DataGenerationHandler>();
            services.AddSingleton<IProvideSqliteConnections, SqliteConnectionProvider>();
            services.AddSingleton<ISqliteSettings, ProgramSettings>();
            services.AddSingleton<IProvideSensorData, SensorDataRepository>();
            services.AddSingleton<IGenerateSensorData, SensorDataRepository>();
            services.AddSingleton<IProvideLastSensorDataValue, SensorDataRepository>();
            services.AddSingleton<IStartupTask, EnsureTableTask>();
            services.AddSingleton<IProvideRandomData, RandomDataProvider>();
            services.AddMvc();

            var serviceProvider = services.BuildServiceProvider();
            var startupTasks = serviceProvider.GetServices<IStartupTask>();
            foreach (var startupTask in startupTasks)
            {
                startupTask.Run();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}