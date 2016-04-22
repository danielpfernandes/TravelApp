﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Data.Entity;
using TravelApp.Models;

namespace TravelApp
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(appEnv.ApplicationBasePath)
              .AddJsonFile("config.json");

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework().AddSqlServer().AddDbContext<TripContext>(
                options =>
            options.UseSqlServer(Configuration["Data:DefaultConnection:TripsConnectionString"])
            );
            services.AddTransient<TripsSeedData>();
            services.AddScoped<TripsRepository>();
            //services.AddIdentity<AppUser, IdentityRole>(config =>
            //{
            //    config.User.RequireUniqueEmail = true;
            //    config.Password.RequiredLength = 8;
            //    config.Password.RequireUppercase = false;
            //    config.Password.RequireNonLetterOrDigit = false;
            //    config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
            //}).AddEntityFrameworkStores<TripContext>();
        }

      
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            TripsSeedData seed = new TripsSeedData(new TripContext());
            app.UseIISPlatformHandler();
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }
                 );
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            seed.InsertSeedData();
        }


        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
