using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Self.Core.Interfaces;
using Self.Infrastructure.Data;

namespace Self.Web
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
            ConnfigureCookieSettings(services);

            CreateIdentityIfNotCreated(services);

            // Use SQL Database if in Azure, otherwise, use local database
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production") {
                services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));
            }
            else {
                //Use real database
                services.AddDbContext<AppDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("SelfConnection")));
            }

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddScoped<IWordRepository, WordRepository>();


            #region snippet_AllowAreas
            services.AddMvc()
                    .AddRazorPagesOptions(options => options.AllowAreas = true)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1); ;
            #endregion

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Word/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "mvcAreaRoute",
                  template: "{area:exists}/{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void CreateIdentityIfNotCreated(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var existingUserManager = scope.ServiceProvider
                    .GetService<UserManager<ApplicationUser>>();

                if(existingUserManager == null)
                {
                    services.AddIdentity<ApplicationUser, IdentityRole>()
                        .AddDefaultUI(UIFramework.Bootstrap4)
                        .AddEntityFrameworkStores<AppDbContext>()
                        .AddDefaultTokenProviders();
                }
            }
        }

        private static void ConnfigureCookieSettings(IServiceCollection services) 
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";

                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });
        }
    }
}
