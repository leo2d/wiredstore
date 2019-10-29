using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using Wired.Data.Contexts;
using Wired.Data.Repository.Contracts;
using Wired.Data.Repository.Repository;
using Wired.Models.Entities;

namespace Wired
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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            //var connection = Configuration["ConnectionStrings:azure"];
            var connection = Configuration["ConnectionStrings:wired_n"];

            services.AddDbContext<WiredContext>(options => options.UseMySql(connection));
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAdministratorRepository, AdministratorRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<ICartIemRepository, CartItemRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("pt-BR");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
                options.RequestCultureProviders.Clear();
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = false;
            });

            //services.AddIdentity<User, IdentityRole>()
            //                                        .AddEntityFrameworkStores<WiredContext>()
            //                                        .AddDefaultTokenProviders();

            //services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                     .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

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
            // app.UseCookiePolicy();

            app.UseRequestLocalization();
            app.UseSession();
            //app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });

            //DbStarter<WiredContext>.Initialize(context);
        }
    }

}