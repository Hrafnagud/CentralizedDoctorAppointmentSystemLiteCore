using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteBusinessLogicLayer.EmailService;
using CDASLiteBusinessLogicLayer.Implementations;
using CDASLiteDataAccessLayer;
using CDASLiteEntityLayer.Enums;
using CDASLiteEntityLayer.IdentityModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI
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
            //begin myComment# To perform connection string connection for Aspnet, dbcontext must be added into its services.
            services.AddDbContext<MyContext> (options => {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });
            //end myComment#

            //begin #myComment# To solidify IUnitOfWork and EmailSender. If we come across to IUW or IES, their object will be created!
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IClaimsTransformation, ClaimProvider.ClaimProvider>();
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("GenderPolicy", policy => policy.RequireClaim("gender", Genders.Male.ToString()));
            });
            //end myComment#
            services.AddControllersWithViews().AddRazorRuntimeCompilation();    //Razor page changes will be able to compiled without stopping IIS.
            //begin myComment#
            services.AddRazorPages();
            services.AddMvc();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60); //Logout due to inactivity
            });
            services.AddIdentity< AppUser, AppRole >(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
                opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();
            //end myComment#
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //begin myComment#
            app.UseStaticFiles();       //For wwwroot folder
            app.UseRouting();           //For Routing mechanism
            app.UseSession();           //For Session mechanism
            app.UseAuthentication();    //To use login logout
            app.UseAuthorization();     //To use authorization attribute
            //end myComment#

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //start myComment#, specificatiton for areas
                endpoints.MapAreaControllerRoute(
                    "management",
                    "management",
                    "management/{controller=Admin}/{action=Index}/{id?}"
                    );
                //end myComment#
            });
        }
    }
}
