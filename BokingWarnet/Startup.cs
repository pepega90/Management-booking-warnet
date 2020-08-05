using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BokingWarnet.Models;
using BokingWarnet.Models.DomainClass;
using BokingWarnet.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BokingWarnet
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
            // Register MVC approach
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
                // Global Otorisasi
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            // Connect to database
            services.AddDbContextPool<AppDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("BokingWarnet"));
            });
            
            // Register Repository dan Implementation
            services.AddScoped<IKomputerRepository, KomputerRepository>();
            services.AddScoped<IOrangBookingRepository, OrangBookingRepository>();

            // Register Identity
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<AppDbContext>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
