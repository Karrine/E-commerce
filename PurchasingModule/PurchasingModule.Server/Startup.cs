using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using PurchasingModule.DAL.Interfaces;
using PurchasingModule.DAL.Models;
using PurchasingModule.DAL.Patterns;
using PurchasingModule.Server.Services.CartService;
using PurchasingModule.Server.Services.OrderService;
using PurchasingModule.Server.Services.ProductCartService;

namespace PurchasingModule.Server
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc()
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
               .AddJsonOptions(options => {
                    // send back a ISO date
                    var settings = options.SerializerSettings;
                   settings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                    // dont mess with case of properties
                    var resolver = options.SerializerSettings.ContractResolver as DefaultContractResolver;
                   resolver.NamingStrategy = null;
               });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<PurchasingContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("PurchasingDB")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IProductCartService, ProductCartService>();
            services.AddTransient<IOrderService, OrderService>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
