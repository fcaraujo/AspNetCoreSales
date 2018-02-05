using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANC.Sales.Data.Context;
using ANC.Sales.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreSales
{
    public class Startup
    {
        private readonly IConfiguration _config;

        #region Ctor

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        #endregion Ctor


        #region Runtime configuration

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(ConfigureApplicationContext);

            services.AddTransient<ApplicationSeeder>();

            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
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
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Seed application 
            if (env.IsDevelopment())
            {
                SeedApplicationDatabase(app);
            }
        }

        #endregion Runtime configuration


        #region Private configuration

        private void ConfigureApplicationContext(DbContextOptionsBuilder obj)
        {
            // TODO: configure SqlLite
            obj.UseSqlite(_config.GetConnectionString("Default"));
        }

        private void SeedApplicationDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<ApplicationSeeder>();
                if (seeder != null)
                {
                    seeder.Seed();
                }
            }
        }

        #endregion Private configuration
    }
}
