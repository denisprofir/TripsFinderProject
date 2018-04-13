using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TripsFinder.Data.Context;
using TripsFinder.Data.Domain.DomainModels.Identity;
using TripsFinder.Web.Models;
using TripsFinder.Web.Services;

namespace TripsFinder.Web
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
            services.AddDbContext<TripsFinderContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TripsFinderConnection")));

            // add authentication services
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<TripsFinderContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = Configuration["AppId"];
                options.AppSecret = Configuration["AppSecret"];
            });

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = Configuration["ClientId"];
                options.ClientSecret = Configuration["ClientSecret"];
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            // Add automapper dependecies
            services.AddAutoMapper(config => config.AddProfiles(Assembly.Load("TripsFinder.Infrastructure")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
          
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
