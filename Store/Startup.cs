using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Bl;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Areas.Admin.Bl;

namespace Store
{
    public class Startup
    {
        IConfiguration config;
        public Startup(IConfiguration configuration)
        {
            config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<StoreContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Start of Sesstion
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            // End Sesstion

            services.AddScoped<IClsHomePage, ClsHomePage>();

            services.AddScoped<IClsItemsCat, ClsItemsCat>();

            // Admin
            services.AddScoped<IClsItemImage, ClsItemImage>();

            services.AddScoped<IClsItem, ClsItem>();

            services.AddScoped<IClsItemDiscount, ClsItemDiscount>();

            services.AddScoped<IClsSlider, ClsSlider>();

            services.AddScoped<IClsCategory, ClsCategory>();

            services.AddScoped<IClsSubCategory, ClsSubCategory>();
            // End Admin

            //Identity Framwork
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = true;

                options.Password.RequiredLength = 8;

                options.Password.RequireNonAlphanumeric = true;

                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<StoreContext>();
            // End Identity Framwork

            services.ConfigureApplicationCookie(options => {

                options.AccessDeniedPath = "/Users/AccessDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = "/Users/Login";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            // Identity
            app.UseAuthentication();

            app.UseAuthorization();
            // Identity

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
