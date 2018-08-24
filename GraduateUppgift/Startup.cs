using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduateUppgift.Core.Persistence;
using GraduateUppgift.Core.Persistence.Models;
using GraduateUppgift.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GraduateUppgift
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      //services.AddDbContext<ForecastContext>(opt => opt.UseInMemoryDatabase("Forecast"));
            services.AddDbContext<ForecastContext>(opt => opt.UseSqlServer(Configuration["ConnectionString"]));
            services.AddSingleton<IForecastService>(new ForecastService(Configuration["ForecastApiKey"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ForecastContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //var context = app.ApplicationServices.GetService<ForecastContext>();
            //GenerateTestData(context);

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        private void GenerateTestData(ForecastContext context)
        {
            //var sweden = new Country
            //{
            //  CountryId = 1,
            //  Name = "Sverige",
            //  CountryCode = "SV"
            //};

            //var stockholm = new City
            //{
            //  CityId = 2673730,
            //  Name = "Stockholm",
            //  CountryId = 1
            //};

            //context.Countries.Add(sweden);
            //context.Cities.Add(stockholm);

            //context.SaveChanges(); 
        }
    }
}
